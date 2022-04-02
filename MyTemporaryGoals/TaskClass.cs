using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;
using MyTemporaryGoals.Layout;
using MyTemporaryGoals.DataManipulation;

namespace MyTemporaryGoals
{

    
    public class TaskClass : Layout.Item
    {
        /* Each taskclass contains one task. The class has all the options to create a task
         * 
         */

        // These are all the properties of a class
        public TaskProperty property = new TaskProperty();

        public TaskClass() { }

        public void CreateEmptyTask()
        {
            // Creates an example task
            CreateTask();
            DataTransfer.task.Add(this);
        }

        public void CreateTask()
        {
            // Option of Grid
            VerticalOptions = LayoutOptions.Start;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Orientation = StackOrientation.Horizontal;

            //* Define Container of Info and Icons
            Grid taskGrid = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto},
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star},
                    new ColumnDefinition { Width = GridLength.Auto },
                }
            };

            StackLayout TaskInformation = new StackLayout() {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label() { Text = property.periode.ToString(), FontSize = Fonts.Size.TaskLabels() },
                    new Label() { Text = property.category.ToString(), FontSize = Fonts.Size.TaskLabels() },
                    //new Label() { Text = "Date", FontSize = 1}
                }
                };
            taskGrid.Children.Add(
                new Entry() {
                    Text = property.name,
                    FontSize = Fonts.Size.TaskDescription(),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                },
             0, 0);
            taskGrid.Children.Add(TaskInformation,
             1,0);
            CheckBox checkBox = new CheckBox
            {
                HorizontalOptions = LayoutOptions.Start,
            };
            checkBox.CheckedChanged += (sender, e) =>
            {

            };
            Children.Add(checkBox);
            Children.Add(taskGrid);

            BackgroundColor = Colors.Task();
        }
    }
    public class TaskProperty
    {
        // Object with all the different fields inside

        public enum FieldType
        {
            // All the possible fields of a TaskClass
            name,
            description,
            periode,
            category,
            renewable,

        };
        public enum PeriodeType
        {
            // Types of Periodes
            day,
            week,
            month,
            year
        };
        public enum Category
        {
            // Types of Periodes
            work,
            hobby,
            custom,
            other
        };


        public TaskProperty(string fname = "", string fdescription = "", PeriodeType fperiode = PeriodeType.day, Category fcategory = Category.hobby, bool frenewable = true) 
        {
            name = fname;
            description = fdescription;
            periode = fperiode;
            category = fcategory;
            renewable = frenewable;
        }

        public string name { set; get; }
        public string description { set; get; }
        public PeriodeType periode { set; get; }
        public Category category { set; get; }
        public bool renewable { set; get; }

        public static List<Enum> getEnumList(FieldType field)
        {
            List<Enum> enums = new List<Enum>();

            switch (field)
            {
                case FieldType.category:
                    foreach(Category cat in Enum.GetValues(typeof(Category)))
                    {
                        enums.Add(cat);
                    }
                    break;
                case FieldType.periode:
                    foreach (PeriodeType p in Enum.GetValues(typeof(PeriodeType)))
                    {
                        enums.Add(p);
                    }
                    break;
            }
            return enums;
        }
    }
}