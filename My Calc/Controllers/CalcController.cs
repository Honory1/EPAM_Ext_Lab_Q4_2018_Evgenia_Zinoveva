using My_Calc.Helpers;
using My_Calc.Models;
using My_Calc.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Calc.Controllers
{
    public class CalcController : Controller
    {
        const int DefaultX = 3;
        const int DefaultY = 32;
        const string DefaultResult = "No data";

        public static List<string> Results = new List<string>();

        // GET: Calc
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Calculate the operation of two integer variables
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View(new CalcModel() { X = DefaultX , Y = DefaultY, Result = DefaultResult });
        }

        /// <summary>
        /// Calculate the operation of two integer variables
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(CalcModel model)
        {
            string result = "";

            switch (model.Op)
            {
                case Operation.Add:
                    {
                        result = (model.X + model.Y).ToString();
                        break;
                    }
                case Operation.Deduct:
                    {
                        result = (model.X - model.Y).ToString();
                        break;
                    }
                case Operation.Share:
                    {
                        if (model.Y == 0)
                            result = "Error! Dividing by zero.";//todo pn строку - в ресурсы
                        else
                            result = (model.X / model.Y).ToString();
                        break;
                    }
                case Operation.Multiply:
                    {
                        result = (model.X * model.Y).ToString();
                        break;
                    }
            }

            string dateTime = DateTime.Now.ToString("dd MMMM yyyy  HH:mm:ss");//todo pn это можно в константу вынести
            
            model.Result = string.Format("{0} {1}{3}{2} = {4}\n", dateTime, model.X, model.Y, model.Op.DisplayName(), result);

            Results.Add(model.Result);

            return View(model);
        }
    }
}