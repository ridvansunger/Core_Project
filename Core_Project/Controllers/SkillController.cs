﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }

        //Ekleme işlemi
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek EKleme";

            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }


        //delete işlemi
        public IActionResult DeleteSkill(int id)
        {

            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek EKleme";
            var values = skillManager.TGetByID(id);
            //skillManager.TUpdate(values);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");

        }
    }
}