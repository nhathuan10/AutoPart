using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using AutoPart.Models;

namespace AutoPart.Controllers
{
    public class ShoppingCart
    {
        //internal member variables
        private string user;
        private DataTable items;
        private double total;
        //public properties
        public string UserID
        {
            get { return user; }
            set { user = value; }
        }
        public DataTable CartItems
        {
            get { return items; }
            set { items = value; }
        }
        public double TotalValue
        {
            get { return total; }
            set { total = value; }
        }
        public object ViewBag { get; private set; }

        public ShoppingCart()
        {
            //create an empty shopping cart
            user = String.Empty;
            // create an empty DataTable to hold the cart items
            items = new DataTable("Items");
            items.Columns.Add(new DataColumn("PartID", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("PartName", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("Condition", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("Image", Type.GetType("System.String")));
            items.Columns.Add(new DataColumn("Quantity", Type.GetType("System.Int32")));
            items.Columns.Add(new DataColumn("Price", Type.GetType("System.Double")));
        }
        public void AddItem(string partId, string partName, string description, string condition, string image, int qty, float price)
        {
            if (!IsExistItem(partId))
            {
                // create new DataTable row and populate with values
                DataRow row = items.NewRow();
                row["PartID"] = partId;
                row["PartName"] = partName;
                row["Description"] = description;
                row["Condition"] = condition;
                row["Image"] = image;
                row["Quantity"] = qty;
                row["Price"] = price;
                //add row to DataTable
                items.Rows.Add(row);
            }
            else
            {
                // increase part quantity
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    if (items.Rows[i]["PartID"].Equals(partId))
                    {
                        items.Rows[i]["Quantity"] = int.Parse(items.Rows[i]["Quantity"].ToString()) + qty;
                        break;
                    }
                }
            }
        }
        public bool IsExistItem(string partId)
        {
            bool b = false;
            if (items.Rows.Count > 0)
            {
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    if (items.Rows[i]["PartID"].Equals(partId))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }
        public void RemoveItem(string partId)
        {
            DataRow[] rows = items.Select("PartId='" + partId + "'");
            if (rows.Length > 0)
            {
                items.Rows.Remove(rows[0]);
            }
        }
        public void Clear()
        {
            items.Rows.Clear();
            total = 0;
        }
        public void ChangeQuantity(string partId, string value)
        {
            for (int i = 0; i < items.Rows.Count; i++)
            {
                if (items.Rows[i][0].Equals(partId) && value == "plus")
                {
                    items.Rows[i]["Quantity"] = int.Parse(items.Rows[i]["Quantity"].ToString()) + 1;
                    break;
                }
                if (items.Rows[i][0].Equals(partId) && value == "minus")
                {
                    if (int.Parse(items.Rows[i]["Quantity"].ToString()) > 1)
                    {
                        items.Rows[i]["Quantity"] = int.Parse(items.Rows[i]["Quantity"].ToString()) - 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    public class OrderingController : Controller
    {
        private MyContext db = new MyContext();
        [ValidateInput(false)]
        public ActionResult AddToCart(string partId, string partName, string description, string condition, string image, float price, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.AddItem(partId, partName, description, condition, image, quantity, price);
            //save cart
            Session["cart"] = cart;
            return RedirectToAction("YourCart");
        }
        public ActionResult YourCart()
        {
            return View();
        }
        public ActionResult RemoveItem(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.RemoveItem(id.ToString());
            return RedirectToAction("YourCart");
        }
        public ActionResult ChangeQuantity(string partId, string value)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.ChangeQuantity(partId, value);
            return RedirectToAction("YourCart");
        }
    }
}