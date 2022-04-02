using System;
namespace Application
{
    class TaskClass : StackLayout
    {
        string Name;

        public TaskClass()
        {

        }

        public StackLayout CreateTask(string text = "Empty Task", TaskKind taskKind = TaskKind.Day)
        {
            StackLayout Task = new StackLayout();
            Task.Orientation = StackOrientation.Horizontal;
            CheckBox checkBox = new CheckBox
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            checkBox.CheckedChanged += (sender, e) =>
            {

            };
            Task.Children.Add(checkBox);
            Task.Children.Add(new StackLayout
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
            return Task;


        }

        public StackLayout TaskField(string Name)
        {
            StackLayout Field = new StackLayout
            {
                Children =
                    {
                        new Label{Text = Name },
                        new Label{Text = "EMpty Text field" },
                    }


            };
            return Field;


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
