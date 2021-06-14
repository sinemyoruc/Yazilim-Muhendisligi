using DostEli.Models;
using DostEli.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DostEli.Controllers
{
    public class AnswerController : BaseController
    {
        public ActionResult Index()
        {
            var model = db.Table_Answer.Where(m => m.User_Id == UserCode).ToList();
            return View(model);
        }

        public ActionResult Create(string Code)
        {
            if (Code == null)
            {
                List<SelectListItem> volunteerList = (

                   from volunteer in db.Table_Volunteer

                   select new SelectListItem
                   {
                       Text = volunteer.V_UserName,
                       Value = volunteer.Volunteer_Id.ToString()
                   }).ToList();

                ViewBag.Volunteer = new SelectList(volunteerList.OrderBy(m => m.Text), "Value", "Text");

                var questionModel = db.Table_Question.ToList();
                return View(questionModel);
            }
            else
            {
                CalculateScore(Code);
                return RedirectToAction("Index");
            }

        }

        public void CalculateScore(string code)
        {
            double yes = 0, no = 0, result = 0;
            var answer = db.Table_Answer.FirstOrDefault(m => m.User_Id == code && m.User_Id == UserCode);
            var answerLine = db.Table_AnswerLine.Where(m => m.AnswerId == answer.A_Id).ToList();

            foreach (var item in answerLine)
            {
                if (item.Answer == Constants.AnswerType.Yes)
                    yes++;
                else
                    no++;

            }
            result = (yes / (yes + no)) * 100;
            if (result > 79)
            {
                answer.IsComplete = true;
            }
            else
            {
                answer.IsComplete = false;
            }
            answer.Score = result.ToString();
            db.SaveChanges();

        }

        public String SendData(AnswerModel answerModel)
        {
            int? month = DateTime.Now.Month;
            var model = db.Table_Answer.FirstOrDefault(m => m.Volunteer_Id == answerModel.Code && m.User_Id == UserCode && m.CreateDay.Value.Month == month);

            if (model != null)
            {
                SaveAnswerLine(answerModel.Question, answerModel.Answer, model.A_Id);
            }
            else
            {
                Table_Answer answer = new Table_Answer();
                answer.Volunteer_Id = answerModel.Code;
                answer.V_FirstName = answerModel.NameSurname;
                answer.User_Id = UserCode;
                answer.CreateDay = DateTime.Now;
                answer.CreateBy = NameSurname;
                db.Table_Answer.Add(answer);
                db.SaveChanges();
                SaveAnswerLine(answerModel.Question, answerModel.Answer, answer.A_Id);
            }
            return "True";
        }

        public void SaveAnswerLine(string question, string answer, int answerId)
        {
            var model = db.Table_AnswerLine.FirstOrDefault(m => m.AnswerId == answerId && m.Question == question);

            if (model != null)
            {
                model.Answer = answer;
                db.SaveChanges();
            }
            else
            {
                Table_AnswerLine answerLine = new Table_AnswerLine();
                answerLine.AnswerId = answerId;
                answerLine.Answer = answer;
                answerLine.Question = question;
                db.Table_AnswerLine.Add(answerLine);
                db.SaveChanges();
            }

        }

        public ActionResult Detail(int? Id)
        {
            var model = db.Table_AnswerLine.Where(m => m.AnswerId == Id).ToList();
            return View(model);
        }

    }
}