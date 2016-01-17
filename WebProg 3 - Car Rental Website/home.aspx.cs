using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProg_3___Car_Rental_Website
{
    public partial class home : System.Web.UI.Page
    {
        public delegate void ListCarDelegate();

        List<Car> cars = new List<Car>();

        //Main connection string to database
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListCarDelegate del = new ListCarDelegate(RetrieveVehicleList);
            del += new ListCarDelegate(DisplayVehicleList);

            del();
        }

        private void RetrieveVehicleList()
        {
            var query = from vehicle in db.Vehicles
                        join brand in db.CarBrands on vehicle.BrandID equals brand.BrandID
                        join model in db.BrandModels on vehicle.ModelID equals model.ModelID
                        join gearbox in db.GearboxTypes on vehicle.GearboxID equals gearbox.GearboxID
                        join fuel in db.FuelTypes on vehicle.FuelID equals fuel.FuelID
                        orderby vehicle.Price ascending
                        select new
                        {
                            id = vehicle.VehicleID,
                            brand = brand.BrandName,
                            model = model.ModelName,
                            gearbox = gearbox.GearboxType1,
                            fuel = fuel.FuelType1,
                            doors = vehicle.Doors,
                            seats = vehicle.Seats,
                            suitcases = vehicle.Suitcases,
                            bags = vehicle.Bags,
                            price = vehicle.Price,
                            image = vehicle.Image
                        };

            foreach (var car in query)
            {
                Car newCar = new Car(car.id, car.brand, car.model, car.gearbox, car.fuel, car.doors, car.seats, car.suitcases, car.bags, car.price, car.image);
                cars.Add(newCar);
            }
        }

        private void DisplayVehicleList()
        {
            foreach (Car _car in cars)
            {
                Panel headingDiv = new Panel();
                headingDiv.CssClass = "panel-heading";
                headingDiv.Controls.Add(new Literal()
                {
                    Text = _car.Brand + " " + _car.Model + "<span class='pull-right'>€"
                            + _car.Price.ToString("F") + "/day</span>"
                });

                Panel bodyDiv = new Panel();
                bodyDiv.CssClass = "panel-body";
                bodyDiv.Controls.Add(new Literal()
                {
                    Text = "<div class='car-image col-xs-12 col-md-3 text-center'><img src='"
                            + _car.Image
                            + "'/></div><div class='car-detail col-xs-6 col-md-3'><i class='fa fa-users fa-2x'><span class='car-panel-text'>"
                            + _car.Seats
                            + " Seats</span></i></div><div class='car-detail col-xs-6 col-md-3'><i class='fa fa-suitcase fa-2x'><span class='car-panel-text'>"
                            + _car.Suitcases
                            + " Suitcase(s) </span></i></div><div class='car-detail col-xs-6 col-md-3'><i class='fa fa-briefcase fa-2x'><span class='car-panel-text'>"
                            + _car.Bags
                            + " Bag(s)</span></i></div><div class='car-detail col-xs-6 col-md-3'><i class='fa fa-car fa-2x'><span class='car-panel-text'>"
                            + _car.Doors
                            + " Door</span></i></div><div class='car-detail col-xs-6 col-md-3'><i class='fa fa-cogs fa-2x'><span class='car-panel-text'>"
                            + _car.Gearbox
                            + "</span></i></div>"
                });

                Panel btnDiv = new Panel();
                btnDiv.CssClass = "car-detail col-xs-12 col-md-3";

                Button btn = new Button();
                btn.ID = Convert.ToString(_car.ID);
                btn.CssClass = "btn btn-warning col-xs-12";
                btn.Text = "Book Me";
                btn.Click += new EventHandler(BookMe_Click);
                btnDiv.Controls.Add(btn);

                bodyDiv.Controls.Add(btnDiv);

                Panel outerDiv = new Panel();
                outerDiv.CssClass = "panel panel-primary";
                outerDiv.Controls.Add(headingDiv);
                outerDiv.Controls.Add(bodyDiv);

                carListMain.Controls.Add(outerDiv);
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
        }

        private void BookMe_Click(object sender, EventArgs e)
        {
            Response.Redirect("signIn.aspx");
        }
    }
}