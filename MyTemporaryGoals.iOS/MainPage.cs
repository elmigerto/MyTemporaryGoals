using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using UIKit;


namespace MyTemporaryGoals
{
    public class MainPage:ContentPage, UITabBarController
    {

        StackLayout TaskField = new StackLayout
        {
            Children =
            {
                
            }
        };
        public MainPage()
        {
            
            this.Padding = new Thickness(20, 20, 20, 20);
            this.BackgroundColor = Color.Black;

            // Predefines all essential buttons
            Button AddGoalButton = new Button
            {
                Text = "Add new goal",
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            AddGoalButton.Clicked += CreateTask;
            Grid FrontPage = new Grid
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                }
            };
            FrontPage.Children.Add(

                    // This is the header of the app
                    new StackLayout
                    {
                        Spacing = 10,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.Black,
                       

                        Children =
                        {
                            new Label
                            {
                                Text = "Your Goal Planer",
                                TextColor = Color.White,
                                FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
                                HorizontalOptions = LayoutOptions.StartAndExpand
                            },
                            new Label
                            {
                                TextColor = Color.White,
                                FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
                                Text ="Date & Time",
                                HorizontalOptions = LayoutOptions.EndAndExpand
                            }
                        }

                    }, 0, 1, 0, 1);
            // This is the first line to interact with
            FrontPage.Children.Add(new StackLayout
            {
                Spacing = 10,
                BackgroundColor = Color.LightGray,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children =
                        {
                            AddGoalButton,
                            new Button
                            {
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Text ="ButtonB"
                            },
                            new Button
                            {
                                HorizontalOptions = LayoutOptions.EndAndExpand,
                                Text ="ButtonC"
                            }
                        }

            }, 0, 1, 1, 2);

            //This is where all the goals goes
            FrontPage.Children.Add(
                    new ScrollView
                    {
                        BackgroundColor = Color.LightBlue,
                        Content = TaskField,

                    }, 0, 1, 2, 3);
            //This is the footer

            FrontPage.Children.Add(new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                            // This is the interacting footer
                            new StackLayout
                            {
                                Spacing = 5,
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                BackgroundColor= Color.LightGray,
                                Children =
                                {
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        Text ="Button 1"
                                        
                                    },
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        Text ="Button 2"
                                    },
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                        Text ="Button 3"
                                    }
                                }

                            },
                            // This is the final footer
                            new StackLayout
                            {
                                Spacing = 10,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Orientation = StackOrientation.Horizontal,
                                BackgroundColor= Color.Black,
                                Children =
                                {
                                    new Label
                                    {
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        Text = "Created by Tobias Elmiger",
                                        TextColor = Color.White,
                                        FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label)),
                                    },
                                    new Label
                                    {
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                        Text = "Report bugs to tellmiger@gmail.com",
                                        TextColor = Color.White,
                                        FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label)),
                                    }
                                }

                            }
                        }
            }

                , 0, 1, 3, 4);
            

            
            this.Content = FrontPage;
        }
        private async void CreateTask(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddTaskWindow");
            TaskField.Children.Add(new TaskClass("First Test",TaskKind.Day));
        }
        private void CheckTask(object sender, EventArgs e)
        {
            
        }
        class TaskClass:StackLayout
        {
            public TaskClass(string text = "Empty Task", TaskKind taskKind = TaskKind.Day)
            {
                this.Orientation = StackOrientation.Horizontal;
                CheckBox checkBox = new CheckBox
                {
                    HorizontalOptions = LayoutOptions.Start,

                };
                checkBox.CheckedChanged += (sender, e) =>
                {

                };
                this.Children.Add(checkBox);
                this.Children.Add(new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Start,

                Children = {
                            new Label
                            {
                                Text = text
                            },
                            new Label
                            {
                                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                                TextColor = Color.LightGray,
                                Text = "Date added: ",
                            } }
                });
             

            }
        }
       

        enum TaskKind
        {
            Day,
            Week,
            Month,
            Year
        }
   
    }

}
