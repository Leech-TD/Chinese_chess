using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.InteropServices;

namespace 中国象棋
{
    class MusicPlayer
    {
        #region  -用API实现MP3等音频文件的播放类-
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);
        private string m_musicPath = "";
        private IntPtr m_Handle;
        #endregion

        #region -定义构造函数-
        public MusicPlayer(string musicPath, IntPtr Handle)

        { 
            m_musicPath = musicPath;
            m_Handle = Handle; 
         }
        #endregion
        #region - 播放音乐 -       
        public void Mp3_Play(string path)
        {
            if (path != "")
            {
                try
                {
                    mciSendString("open " + path + " alias media", null, 0, m_Handle);
                    mciSendString("play media", null, 0, m_Handle);
                }
                catch (Exception)
                {

                }

            }
        }
        public void Mp3_Play()
        {
            Mp3_Play(m_musicPath);
        }
        #endregion
        #region - 停止音乐播放 -    
       public void CloseMedia()
        {
            try
            {
                mciSendString("close all", null, 0, m_Handle);
            }
            catch (Exception)
            {
            }
        }
        #endregion



        /// <summary>
        /// 播放音效,用SoundPlayer实现对.wav播放
        /// </summary>
        /// <param name="path"></param>
        private static SoundPlayer soundPlayer = new SoundPlayer();
        public static void play(string command) {
            switch (command) {
                case "normall":
                    soundPlayer.SoundLocation = @"sound\select.wav";
                    soundPlayer.Play();
                    break;
                case "吃子":
                    soundPlayer.SoundLocation = @"sound\eat.wav";
                    soundPlayer.Play();
                    break;
                default: break;
            }
        }
    }
}
