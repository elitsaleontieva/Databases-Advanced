﻿using System;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (var db = new StudentSystemContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
