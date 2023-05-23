// See https://aka.ms/new-console-template for more information
using BMIApp.Repository;
using BMIApp.CRUD;
using BMIApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            BmiContext bmiContext = new BmiContext();

            Log log = new Log();    

            Print.printMenu();

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Save save1 = new Save(bmiContext,log);
                    save1.SaveName();
                    break;

                case "2":
                    Delete delete = new Delete(bmiContext, log);
                    delete.delete();
                    break;

                case "3":
                    Edit edit = new Edit(bmiContext,log);
                    edit.editMember();
                    break;

                case "4":
                    Calculator calculator = new Calculator(bmiContext,log);
                    calculator.Calculate();
                    break;

                default:
                    break;
            }
        }

    }
}











