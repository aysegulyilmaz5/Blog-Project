﻿using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAcessLayer.Concrete;
using DataAcessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    

    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var context = stream.ToArray();
                    return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }



        }

        public List<BlogModel> GetBlogList()
        {

            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID = 1 , BlogName= "Samet Akca"},
                new BlogModel{ID = 2 , BlogName= "Eslem Betül"},
                new BlogModel{ID = 3 , BlogName= "test"}
            };
            return bm;

        }




        public IActionResult BlogListExcel()
        {
            return View();
        }



       

        public IActionResult ExportDinamikExcelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";


                int BlogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var context = stream.ToArray();
                    return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var db = new Context())
            {
                bm = db.Blogs.Select(x => new BlogModel2
                {

                    ID = x.BlogID,
                    BlogName = x.BlogtTitle
                }).ToList();
            }

            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

    }
}