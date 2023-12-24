


namespace MauiApp3
{
    public partial class Chose : ContentPage
    {
        public static List<string> textList { get; private set; } = new List<string>();
        public Chose()
        {
            InitializeComponent();
            textList = new List<string>();

        }
        private void OnShowTextClicked(object sender, EventArgs e)
        {
            // 获取输入框中的文本
            string userInput = inputEntry.Text;

            // 将文本添加到列表
            textList.Insert(0, userInput);

            // 保留最近的九个文本
            textList = textList.Take(9).ToList();

            UpdateFlexLayout();
            

        }
        private void UpdateFlexLayout()
        {
            // 清除现有内容
            outputFlexLayout.Children.Clear();

            // 添加文本和按钮到 FlexLayout
            foreach (var text in textList)
            {
                var label = new Label { Text = text };
                var button = new Button { Text = "移除", CommandParameter = text };
                button.Clicked += OnButtonClicked;

                outputFlexLayout.Children.Add(label);
                outputFlexLayout.Children.Add(button);
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // 处理按钮点击事件
            var buttonText = (sender as Button).CommandParameter as string;
     
            // 從列表中移除相應的文字
            textList.Remove(buttonText);

           

            // 更新 FlexLayout 顯示的文本和按鈕
            UpdateFlexLayout();
            
        }
        private async void OnClicked(object sender, EventArgs e)
        {
            if (textList.Count>1)
            {
                Navigation.PushAsync(new MainPage());
            }
            if (textList.Count <= 1)
            {
                await DisplayAlert("提醒", "請加入至少兩個選擇", "確定");
            } 
        }
    }
}

