using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineTricariOtomasyon.Models.Classes
{
    public class Context : DbContext
    {
        //Database yansıtmak için
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<SalesMotion> SalesMotions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PDetail> PDetail { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracing> CargoTracings { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}