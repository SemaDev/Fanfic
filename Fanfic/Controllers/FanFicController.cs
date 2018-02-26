using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fanfic.Data;
using Fanfic.Models;
using Fanfic.Models.FanFicViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fanfic.Controllers
{
    [Authorize]
    public class FanFicController : Controller
    {
        ApplicationDbContext dbContext;
        UserManager<ApplicationUser> _userManager;

        public FanFicController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            dbContext = context;
            _userManager = manager;
        }

        public IActionResult Create()
        {
            return View(new Models.Fanfic());
        }

        public IActionResult Edit(int idfanfic)
        {
            return View("Create",dbContext.Fanfics.Find(idfanfic));
        }

        [HttpGet]
        public JsonResult GetJanres(string searchTerm)
        {
            var janres = dbContext.Janres.ToList();
            if (searchTerm != null)
                janres = dbContext.Janres.Where(search => search.Caption.ToString().Contains(searchTerm)).ToList();
            var resultData = janres.Select(janre => new
            {
                id = janre.Id,
                text = janre.Caption
            });
            return Json(resultData);
        }

        [HttpGet]
        public JsonResult GetTags(string searchTerm)
        {
            var tags = dbContext.Tags.ToList();
            if (searchTerm != null)
                tags = dbContext.Tags.Where(search => search.Text.ToString().Contains(searchTerm)).ToList();
            var resultData = tags.Select(tag => new
            {
                id = tag.Id,
                text = tag.Text
            });
            return Json(resultData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFanfic(int id_fanfic, string[] tags, string janre, string caption, string discription, string picture)
        {
            Models.Fanfic fanfic = dbContext.Fanfics.Where(fan => fan.Id == id_fanfic).Include(f => f.Chapters).FirstOrDefault();
            bool edit = true;
            if (fanfic == null)
            {
                edit = false;
                fanfic = new Models.Fanfic();
            }
            if (janre == null) janre = "1";
            fanfic.Janre = dbContext.Janres.Where(j => j.Id == Convert.ToInt32(janre)).First();
            fanfic.Description = discription;
            fanfic.Picture = picture;
            fanfic.ApplicationUser = await _userManager.GetUserAsync(User);
            fanfic.Name = caption;
            fanfic.CreateDate = DateTime.Now;
            if (edit)
                dbContext.Update(fanfic);
            else
                fanfic = dbContext.Add(fanfic).Entity;
            await dbContext.SaveChangesAsync();
            await addFanficTags(fanfic,await addNewTags(tags));
            return View("Chapter", new FanficMainInfoViewModel { Fanfic = fanfic, Chapter = new Chapter()});
        }

        public IActionResult NewChapter (int fanficId)
        {
            var fanfic = dbContext.Fanfics.Where(f => f.Id == fanficId).Include(c => c.Chapters).FirstOrDefault();
            return View("Chapter", new FanficMainInfoViewModel { Fanfic = fanfic, Chapter = new Chapter() });
        }

        private async Task addFanficTags(Models.Fanfic fanfic, List<Tag> list)
        {
            foreach (Tag tag in list)
            {
                await dbContext.FanficTag.AddAsync(new FanficTag { Fanfic = fanfic, Tag = tag });
                await dbContext.SaveChangesAsync();
            }

        }

        [AllowAnonymous]
        public IActionResult RenderMarkDown(string data)
        {
            return PartialView("_MarkDownView", new ChapterTextViewModel() { Text = data});
        }

        public IActionResult CreateChapter(string Caption, string Picture, string Text, int fanfic, int chapterId)
        {
            var fanficObj = dbContext.Fanfics.Find(fanfic);
            Chapter chapter;
            if (chapterId == 0)
            {
                chapter = new Chapter { Caption = Caption, Picture = Picture, Text = Text, Fanfic = fanficObj };
                dbContext.Update(chapter);
            }
            else
            {
                chapter = dbContext.Chapters.Find(chapterId);
                chapter.Caption = Caption;
                chapter.Text = Text;
                chapter.Picture = Picture;
                dbContext.Update(chapter);
            }
            
            dbContext.SaveChanges();
            return View("Chapter", new FanficMainInfoViewModel { Fanfic = GetFanficWithChapter(fanficObj), Chapter = new Chapter()});
        }

        [HttpGet]
        public IActionResult ChooseChapter (string data)
        {
            var chapter = dbContext.Chapters.Where(ch => ch.Id == Convert.ToInt32(data)).Include(f => f.Fanfic).FirstOrDefault();
            Models.Fanfic fanfic = dbContext.Fanfics.Where(f => f.Id == chapter.Fanfic.Id).FirstOrDefault();
            return View("chapter", new FanficMainInfoViewModel { Chapter = chapter, Fanfic = GetFanficWithChapter(fanfic) });
        }

        private Models.Fanfic GetFanficWithChapter(Models.Fanfic fanfic)
        {
            var a = dbContext.Chapters.Where(fic => fic.Fanfic.Id == fanfic.Id);
            fanfic.Chapters = a.ToList();
            return fanfic;
        }

        [HttpGet]
        public IActionResult DeleteChapter(string chapterId, string fanficId)
        {
            dbContext.Chapters.Remove(dbContext.Chapters.Find(Convert.ToInt32(chapterId)));
            dbContext.SaveChanges();
            return RedirectToAction("NewChapter",new { fanficId = (Convert.ToInt32(fanficId)) });
        }
        

        private async Task<List<Tag>> addNewTags(string[] tags)
        {
            List<Tag> tagList = new List<Tag>();
            for (int i = 0; i<tags.Length; i++)
            {
                if (!Int32.TryParse(tags[i], out int result))
                {
                    tagList.Add(dbContext.Add(new Tag { Text = tags[i] }).Entity);
                }
                else
                {
                    tagList.Add(dbContext.Tags.Where(search => search.Id == result).First());
                }
            }
            await dbContext.SaveChangesAsync();
            return tagList;
        }

        [AllowAnonymous]
        public IActionResult Open(int idfanfic)
        {
            var fanfic = dbContext.Fanfics.Where(fan => fan.Id == idfanfic).Include(fan => fan.Chapters).FirstOrDefault();
            OpenViewModel model = new OpenViewModel { Fanfic = fanfic, Chapter = fanfic.Chapters.First() };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult OpenNext(int idfanfic, int idChapter)
        {
            var fanfic = dbContext.Fanfics.Where(fan => fan.Id == idfanfic).Include(fan => fan.Chapters).FirstOrDefault();
            int index = fanfic.Chapters.IndexOf(fanfic.Chapters.Find(c => c.Id == idChapter));
            OpenViewModel model;
            if (fanfic.Chapters[index+1] != null)
                model = new OpenViewModel { Fanfic = fanfic, Chapter = fanfic.Chapters[index+1] };
            else
                model = new OpenViewModel { Fanfic = fanfic, Chapter = fanfic.Chapters[0] };
            return View("open",model);
        }

        [AllowAnonymous]
        public IActionResult OpenPrevious(int idfanfic, int idChapter)
        {
            var fanfic = dbContext.Fanfics.Where(fan => fan.Id == idfanfic).Include(fan => fan.Chapters).FirstOrDefault();
            int index = fanfic.Chapters.IndexOf(fanfic.Chapters.Find(c => c.Id == idChapter));
            OpenViewModel model;
            if (index-1<1)
                model = new OpenViewModel { Fanfic = fanfic, Chapter = fanfic.Chapters[index - 1] };
            else
                model = new OpenViewModel { Fanfic = fanfic, Chapter = fanfic.Chapters[0] };
            return View("open", model);
        }

        public IActionResult ReadChapter(int idfanfic, int idChapter)
        {
            var fanfic = dbContext.Fanfics.Where(fan => fan.Id == idfanfic).Include(fan => fan.Chapters).FirstOrDefault();       
            var model = new OpenViewModel { Fanfic = fanfic, Chapter = dbContext.Chapters.Find(idChapter) };
            return View("open", model);
        }
    }
}