using System;
using MyTemporaryGoals.DataManipulation;
using Xamarin.Forms;
using MyTemporaryGoals.Layout;

namespace MyTemporaryGoals
{
    public class MainPage:Layout.Page
    {
        // Parameter
        


        public StackLayout TaskField = new StackLayout
        {
            Children =
            {
                
            }
        };

        public void initialization()
        {
            TaskClass task = new TaskClass();
            task.CreateEmptyTask();
            AddTask(task);
        }

        public MainPage()
        {
            
            

            // Predefines all essential buttons
            Button AddGoalButton = new Button
            {
                Text = "Add new goal",
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            AddGoalButton.Clicked += TaskWindow;
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
                    new ColumnDefinition { //Width = new GridLength(1, GridUnitType.Star)
                                          },
                }
            };
            FrontPage.Children.Add(
                    // This is the header of the app
                    new Header
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "UrLife",
                                TextColor = Color.White,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                HorizontalOptions = LayoutOptions.StartAndExpand
                            }
                        }
                    });
            // This is the first line to interact with
            FrontPage.Children.Add(new ButtonRow
            {

                Children =
                        {
                            AddGoalButton,
                            new Button
                            {
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Text = Text.MainPageButtonArchiv
                            },
                            new Button
                            {
                                HorizontalOptions = LayoutOptions.EndAndExpand,
                                Text = Text.MainPageButtonSort
                            }
                        }

            }, 0, 1, 1, 2); ;

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
                            new ButtonRow
                            {
                                Children =
                                {
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        Text ="Progress"

                                    },
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        Text ="Preferences"
                                    },
                                    new Button
                                    {
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                        Text ="Profile"
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

            this.Content= FrontPage;
            initialization();
        }
        public void AddTask(TaskClass task)
        {
            TaskField.Children.Add(task);
        }
        public void ResetTasks()
        {
            TaskField.Children.Clear();
        }
        private async void TaskWindow(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new AddTaskWindow(new Action (UpdateTasks)));
            
            //
        }
        public void UpdateTasks()
        {
            ResetTasks();
            foreach(TaskClass task in DataTransfer.task)
            {
                AddTask(task);
            }
        }
        private void CheckTask(object sender, EventArgs e)
        {
            
        }

       
   
    }
    

}
