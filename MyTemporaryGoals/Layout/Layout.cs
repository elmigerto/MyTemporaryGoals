using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace MyTemporaryGoals.Layout
{
    /* Layout is a Namespace with classes containing layouts
     * The Layout namespaces contains different layout class such as buttons, labels, headers, which can be initialized like a class
     */



    // FONTs
    public static class Fonts {
        public static class Size
        {
            public static double TaskLabels()
            {
                return Device.GetNamedSize(NamedSize.Small, typeof(Label));
            }
            public static double TaskDescription()
            {
                return Device.GetNamedSize(NamedSize.Small, typeof(Label));
            }
        }
    }

    // COLORS
    public static class Colors
    {
        public static Color Task()
        {
            return new Xamarin.Forms.Color(230, 230, 230);
        }
        public static Color Button
        {
            get { return new Xamarin.Forms.Color(245, 245, 230); }
        }
        public static Color ButtonRow
        {
            get { return new Xamarin.Forms.Color(250, 250, 245); }
        }
    }


    // Stacklayouts

    public class General : StackLayout
    {
        public General()
        {
            Padding = 10;
            Spacing = 5;
        }
    }
    public class ButtonRow : General
    {
        public ButtonRow()
        {
            Spacing = 2;
            HorizontalOptions = LayoutOptions.Start;
            Orientation = StackOrientation.Horizontal;
            BackgroundColor = Colors.ButtonRow;
        }
    }
    //Stacklayout
    public class ButtonBasic : Button
    {
        public ButtonBasic(string text)
        {
            Text = text;
            BackgroundColor = Colors.Button;
            BorderColor = Color.DarkGray;
            BorderWidth = 1;
            TextColor = Color.Black;
            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
        public Enum EmumValue { get; set; }
    }
    public class Header : StackLayout
    {
        public Header()
        {
            GeneralOptions(); 
        }
        public Header(string text)
        {
            GeneralOptions();
            Children.Add(new Label
            {
                Text = text,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.StartAndExpand
            }); 

        }
        public void GeneralOptions()
        {
            this.BackgroundColor = Color.LightBlue;
            Spacing = 10;
            Padding = 5;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Orientation = StackOrientation.Horizontal;
            
        }
        public void AddLabel(string text = "", Color color = default(Color))
        {
            Children.Add(new Label
            {
                Text = text,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.StartAndExpand
            });
        }
    }
    public class Fields : StackLayout
    {
        // TEnum is used to add itemms of type TEnum
        public Fields(TaskProperty.FieldType fieldType, Enum returnValue)
        {
            GeneralOptions();
            AddEnumLabels(fieldType, returnValue);
        }
        public void GeneralOptions()
        {
            this.BackgroundColor = Color.White;
            Spacing = 10;
            Padding = 10;
            HeightRequest = Width * 0.03;

            VerticalOptions = LayoutOptions.FillAndExpand;
            Orientation = StackOrientation.Horizontal;
        }
        public void AddEnumLabels(TaskProperty.FieldType fieldType, Enum returnValue)
        {
            var buttonEnums = TaskProperty.getEnumList(fieldType);

            AddLabel(fieldType.ToString());
            foreach(var name in buttonEnums)
            {
                var button = new ButtonBasic(name.ToString());
                button.EmumValue = name;
                button.Clicked += (sender, args) => { returnValue = name; };
                Children.Add(button);
            }
        }
      
        public void AddLabel(string text = "", Color color = default(Color))
        {

            Children.Add(new Label
            {
                Text = text,
                BackgroundColor = Color.LightGray,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand
            });
            ;
        }
        public void AddButton(string text = "")
        {
            var button = new ButtonBasic(text);
            Children.Add(button);
        }
    }
    public class Page : ContentPage
    {
        public Page()
        {
            this.Padding = new Thickness(20, 20, 20, 20);
            this.BackgroundColor = Color.White;
        }
     
    }
    public class PageLayout : StackLayout
    {
        public PageLayout()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
        }
    }
    public class Item : StackLayout
    {
        public Item()
        {

        }
    }
    public class Label_Standard : Label
    {
        public Label_Standard()
        {
            TextColor = Color.Black;
        }

    }
    public class EmptyField : Label
    {
        public EmptyField()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
        }
    }
    public class WindowBar:StackLayout
    {
        /* Window bar with buttons
         *  Has different type such as SaveCancel
         */

        ContentPage contentPage;
        public WindowBar(string[] text )
        {
            GeneralOptions();
            foreach (string t in text)
            {
                Children.Add(AddButton(t));
            }
        }
        public WindowBar(BarType button_type,ContentPage page)
        {
            GeneralOptions();

            contentPage = page;

            string[] text;
            if (button_type == BarType.SaveCancel)
            {
                text = new string []{ "Save", "Cancel" };
                Button saveButton = AddButton("Save");

                saveButton.Clicked += RemovePage;
            }
            else
            {
                text = new string[] { "Ok" };
                foreach (string t in text)
                {
                    Children.Add(AddButton(t));
                }
            }
        }
        public void GeneralOptions()
        {
            this.BackgroundColor = Color.White;
            Spacing = 50;
            Padding = 30;
            HeightRequest = Width * 0.01;

            VerticalOptions = LayoutOptions.FillAndExpand;
            
            Orientation = StackOrientation.Horizontal;
        }
        private void RemovePage(object sender,EventArgs e)
        {
            Navigation.RemovePage(contentPage);
            
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
    }
    public class choices:StackLayout
    {
        public choices(string []text, bool returnValue)
        {

            GeneralOptions();
            foreach ( string t in text)
            {
                Children.Add(Option(t,returnValue));
            }
        }
        public void GeneralOptions()
        {
            this.BackgroundColor = Color.White;
            Spacing = 50;
            Padding = 30;
            HeightRequest = Width * 0.01;


            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            Orientation = StackOrientation.Horizontal;
        }
        public StackLayout Option(string text,bool returnValue)
        {

            CheckBox checkBox = new CheckBox
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            checkBox.CheckedChanged += (sender, e) =>
            {         
                returnValue = checkBox.IsChecked;
                Console.WriteLine("Renewalbe change to" + returnValue.ToString());
            };
            return new StackLayout()
            {
            Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        Text = text
                    },
                    checkBox
                }
            };
        }
    }
}
