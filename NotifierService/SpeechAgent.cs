using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Text;

namespace NotifierService
{
    static class SpeechAgent
    {
        private static SpeechSynthesizer _synthesizer;

        static SpeechAgent()
        {
            _synthesizer = new SpeechSynthesizer();
            _synthesizer.Rate = -2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Notify(string speech)
        {
            if (speech.ToLower().StartsWith("/m"))
            {
                speech = speech.Replace("/m", "");
                _synthesizer.SelectVoice(ConfigurationManager.AppSettings["MaleSynthVoice"]);
            }
            else if (speech.ToLower().StartsWith("/f"))
            {
                speech = speech.Replace("/f", "");
                _synthesizer.SelectVoice(ConfigurationManager.AppSettings["FemaleSynthVoice"]);
            }
            else
            {
                _synthesizer.SelectVoice(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["DefaultSynthVoice"]]);
            }

            _synthesizer.Speak(speech);
        }
    }
}
