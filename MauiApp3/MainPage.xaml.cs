using System;
using Plugin.Maui.Audio;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public static string food;
        private readonly IAudioManager audioManager;
        List<string> textListFromChose = Chose.textList;
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
            InitializePage();
        }
        private void InitializePage()
        {
   
            // 遍历 textListFromChose，将值分配给相应的 Label
            for (int i = 0; i < textListFromChose.Count && i < 9; i++)
            {
                string labelText = textListFromChose[i];

                Label label = FindLabel($"label{i + 1}"); // Assuming your Label names are like "label1", "label2", etc.

                // 分配值给 Label
                label.Text = labelText;
            }
        }
        // 辅助方法，用于根据名称查找 Label 控件
        private Label FindLabel(string name)
        {
            return this.FindByName<Label>(name);
        }
        private Frame FindFrame(string name)
        {
            return this.FindByName<Frame>(name);
        }
        private async void OnStartClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < textListFromChose.Count; i++)
            {
                Frame frame = FindFrame($"Frame{i + 1}");  // Assuming your Label names are like "frame1", "frame2", etc.
                                                           // 改变 Frame 背景颜色
                frame.BackgroundColor = Color.FromHex("#FFFFFF"); // 你可以替换为你想要的颜色
            }
            System.Random random = new System.Random();
            int randomIncrement = random.Next(1, textListFromChose.Count+1);
            for (int j = 0; j < 3; j++)
            {
                if(j!=2)
                {
                    for (int i = 0; i < textListFromChose.Count; i++)
                    {
                        Frame frame = FindFrame($"Frame{i + 1}");  // Assuming your Label names are like "frame1", "frame2", etc.
                                                                   // 改变 Frame 背景颜色
                        frame.BackgroundColor = Color.FromHex("#FFFF00");  // 你可以替换为你想要的颜色
                                                                           // 在0.5秒后还原颜色
                        await Task.Delay(100);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            frame.BackgroundColor = Color.FromHex("#FFFFFF"); // 还原为原始颜色
                        });
                    }
                }
                if (j == 2)
                {
                    for (int i = 0; i < randomIncrement; i++)
                    {
                        if (i != randomIncrement - 1)
                        {
                            Frame frame = FindFrame($"Frame{i + 1}");  // Assuming your Label names are like "frame1", "frame2", etc.
                                                                       // 改变 Frame 背景颜色
                            frame.BackgroundColor = Color.FromHex("#FFFF00");  // 你可以替换为你想要的颜色
                                                                               // 在0.5秒后还原颜色
                            await Task.Delay(100);
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                frame.BackgroundColor = Color.FromHex("#FFFFFF"); // 还原为原始颜色
                            });
                        }
                        if (i == randomIncrement - 1)
                        {
                            Frame frame = FindFrame($"Frame{i + 1}");  // Assuming your Label names are like "frame1", "frame2", etc.
                                                                          // 改变 Frame 背景颜色
                            frame.BackgroundColor = Color.FromHex("#FFFF00");  // 你可以替换为你想要的颜色


                            Label labell = FindLabel($"label{i + 1}"); 
                            food = labell.Text;

                        }
                      
                    }
                }
            }
            await Task.Delay(500);
            Navigation.PushAsync(new Imagemusic(audioManager));
        }
    }

}
