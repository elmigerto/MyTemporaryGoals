using System;
using Xamarin.Forms;
using MyTemporaryGoals.DataManipulation;


namespace MyTemporaryGoals
{
    class AddTaskWindow : Layout.Page
    {
        /*
         *  This class will generate a Task Window where all the options of a task can be added / changed
         *  
         *  
         */

        //** Variables **//
        TaskClass Task;
        Action updateTask;

        // Fields - Text
        public delegate string contentTextField();
        contentTextField getName = () =>  "";
        contentTextField getDescription = () => "";



        public AddTaskWindow(Action FUpdateTasks)
        {
            updateTask = FUpdateTasks;
            Task = new TaskClass();
            TextTaskField nameField = new TextTaskField(TaskProperty.FieldType.name.ToString());
            TextTaskField descriptionField = new TextTaskField(TaskProperty.FieldType.description.ToString());
            getName = () => nameField.entryField.Text;
            getDescription = () => descriptionField.entryField.Text;
            StackLayout FrontPage = new Layout.PageLayout()
            {
                Children = {
                    new Layout.Header("Add your new Task"),
                    nameField,
                    new Layout.Fields(TaskProperty.FieldType.periode,Task.property.periode),
                    new Layout.Fields(TaskProperty.FieldType.category,Task.property.category),
                    new Layout.choices(new string [] {"Renewable" },Task.property.renewable),
                    new Layout.EmptyField(),
                    WindowBar(BarType.SaveCancel),
                }
            };

            this.SetBinding(ContentPage.TitleProperty, "Name");
            // BoxView to show the color.
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };
            boxView.SetBinding(BoxView.ColorProperty, "Color");

            // Build the page
            this.Content = FrontPage;
        }
        public StackLayout WindowBar(BarType button_type)
        {
            StackLayout stackLayout = new StackLayout();

                WindowBarOptions(ref stackLayout);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                string[] text;
                if (button_type == BarType.SaveCancel)
                {
                    text = new string[] { "Save", "Cancel" };
                    Button saveButton = AddButton("Save");
                    Button cancelButton = AddButton("Cancel");
                    saveButton.Clicked += OnSaveButtonEvent;
                    cancelButton.Clicked += OnCancelButtonEvent;
                    stackLayout.Children.Add(saveButton);
                    stackLayout.Children.Add(cancelButton);
                }
                    else
                {
                    text = new string[] { "Ok" };
                    foreach (string t in text)
                    {
                        stackLayout.Children.Add(AddButton(t));
                    }
                }
            return stackLayout;
        }
        public void WindowBarOptions(ref StackLayout layout)
        {
            layout.BackgroundColor = Color.White;
            layout.Spacing = 50;
            layout.Padding = 30;
            layout.HeightRequest = Width * 0.01;


            layout.VerticalOptions = LayoutOptions.FillAndExpand;

            layout.Orientation = StackOrientation.Horizontal;
                
        }
        private void OnSaveButtonEvent(object sender, EventArgs e)
        {
            SaveTask();
            Navigation.RemovePage(this);
        }
        private void OnCancelButtonEvent(object sender, EventArgs e)
        {
            //TaskField.Children.Add(new TaskClass("First Test", TaskKind.Day));
            Navigation.RemovePage(this);

        }
        public Button AddButton(string b_text)
        {
            return new Button
            {
                Text = b_text,
                BackgroundColor = Color.LightGray,
                BorderColor = Color.DarkGray,
                BorderWidth = 1,
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,



            };


        }
        
        void SaveTask()
        {
            var test = getName?.Invoke();
            Task.property.name = getName();
            Task.property.description = getDescription();
            Task.CreateTask();
            DataTransfer.addTask(Task);
            updateTask();
        }
        public String ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

            }
            catch { }
        }
    }
    class TextTaskField : StackLayout
    {

        public Entry entryField { set; get; }
        public ListView dateTypeList
        {
            set;
            get;
        }

        public TextTaskField(string name)
        {
            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            Label description = new Label { Text = name, HorizontalOptions = LayoutOptions.Start };
            Children.Add(description);

            entryField = new Entry();
            entryField.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            entryField.HorizontalOptions = LayoutOptions.FillAndExpand;
            entryField.WidthRequest = 100;
            Children.Add(entryField);
        }
    }

}
