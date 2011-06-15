﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WaveLib
{
    /// <summary>
    /// Provides common mother-wavelets for general purposes
    /// </summary>
    public static class CommonMotherWavelets
    {
        /// <summary>
        /// Wavelet list
        /// </summary>
        public static Dictionary<string, double[]> Wavelets { get; private set; }

        /// <summary>
        /// Static Constructor
        /// </summary>
        static CommonMotherWavelets()
        {
            Wavelets = new Dictionary<string, double[]>
                           {
                               {"coif1", new[]{-0.051429728, 0.23892973, 0.60285946, 0.27214054, -0.051429728, -0.011070272}},
                               {"coif2", new[]{0.011587597, -0.029320138, -0.04763959, 0.27302105, 0.57468239, 0.29486719, -0.054085607, -0.04202648, 0.01674441, 0.0039678836, -0.0012892034, -0.0005095054}},
                               {"coif3", new[]{-0.0026824187, 0.0055031267, 0.01658356, -0.046507764, -0.043220764, 0.28650334, 0.56128526, 0.30298357, -0.050770141, -0.058196251, 0.024434094, 0.011229241, -0.006369601, -0.0018204589, 0.0007902051, 0.00032966517, -5.0192775e-005, -2.4465734e-005}},
                               {"coif4", new[]{0.00063096105, -0.0011522249, -0.005194524, 0.011362459, 0.018867235, -0.057464234, -0.039652649, 0.29366739, 0.55312645, 0.30715733, -0.047112739, -0.068038127, 0.02781364, 0.017735837, -0.010756319, -0.0040010129, 0.0026526659, 0.00089559453, -0.00041650057, -0.00018382977, 4.4080354e-005, 2.2082857e-005, -2.304942e-006, -1.262175e-006}},
                               {"coif5", new[]{-0.0001499638, 0.0002535612, 0.0015402457, -0.0029411108, -0.0071637819, 0.016552066, 0.019917804, -0.064997263, -0.036800074, 0.29809232, 0.54750543, 0.30970685, -0.043866051, -0.074652239, 0.02919588, 0.023110777, -0.013973688, -0.00648009, 0.0047830014, 0.0017206547, -0.0011758222, -0.000451227, 0.0002137298, 9.93776e-005, -2.92321e-005, -1.5072e-005, 2.6408e-006, 1.4593e-006, -1.184e-007, -6.73e-008}},
                               {"db2", new[]{0.34150635, 0.59150635, 0.15849365, -0.09150635}},
                               {"db3", new[]{0.2352336, 0.57055846, 0.3251825, -0.095467208, -0.060416104, 0.02490875}},
                               {"db4", new[]{0.16290171, 0.50547286, 0.44610007, -0.019787513, -0.13225358, 0.02180815, 0.023251801, -0.0074934947}},
                               {"db5", new[]{0.11320949, 0.42697177, 0.51216347, 0.097883481, -0.17132836, -0.022800566, 0.054851329, -0.0044134001, -0.0088959351, 0.002358714}},
                               {"db6", new[]{0.078871216, 0.34975191, 0.53113188, 0.22291566, -0.1599933, -0.091759032, 0.068944046, 0.019461605, -0.022331874, 0.00039162558, 0.0033780312, -0.0007617669}},
                               {"db7", new[]{0.055049715, 0.28039564, 0.51557425, 0.33218624, -0.10175691, -0.15841751, 0.050423233, 0.057001723, -0.026891226, -0.011719971, 0.0088748962, 0.0003037575, -0.0012739524, 0.00025011343}},
                               {"db8", new[]{0.038477811, 0.22123362, 0.47774308, 0.41390827, -0.011192868, -0.20082932, 0.000334097, 0.091038178, -0.01228195, -0.031175103, 0.00988608, 0.00618442, -0.00344385, -0.000277, 0.00047761, -0.00008307}},
                               {"db9", new[]{0.026925175,0.17241715,0.42767453,0.46477286, 0.094184775, -0.20737588, -0.068476775, 0.10503417, 0.021726338, -0.047823632, 0.00017744641, 0.015812083, -0.0033398101, -0.0030274803, 0.0013064836, 0.00016290734, -0.00017816488, 2.7822757e-005}},
                               {"db10", new[]{0.018858579,0.13306109,0.37278754,0.48681406,0.19881887,-0.1766681,-0.13855494,0.090063724,0.065801494,-0.050483286,-0.020829624,0.023484907,0.0025502185,-0.0075895012,0.00098666268,0.0014088433,-0.00048497392,-8.2354503e-005,6.6177183e-005,-9.3792079e-006}},
                               {"haar", new[]{0.5, 0.5}},
                               {"meyer", new[]{-1.0675471e-006, 9.0422391e-007, 3.1790474e-007, -1.4824969e-006, 1.2185021e-006, 4.9361831e-007, -2.0360473e-006, 1.685139e-006, 6.9474288e-007, -2.9824249e-006, 2.3712818e-006, 1.1842062e-006, -4.2670334e-006, 3.4206657e-006, 1.6986728e-006, -6.757326e-006, 5.1028515e-006, 3.4288134e-006, -1.0045807e-005, 7.427383e-006, 4.3752764e-006, -1.7280266e-005, 1.4217352e-005, 1.0602014e-005, -3.2830067e-005, 2.2868742e-005, 2.6452607e-005, -7.2675672e-005, 1.7297201e-005, 0.00010586336, -5.3452188e-005, -9.8933455e-005, -6.6123548e-005, 0.00011397832, 0.00060775794, -0.00040883876, -0.0019107203, 0.0015519393, 0.0042748181, -0.0045160954, -0.0078097348, 0.010784015, 0.012306397, -0.022693911, -0.017198084, 0.045019544, 0.021652472, -0.0938306, -0.024782862, 0.31402235, 0.52591095, 0.31402235, -0.024782862, -0.0938306, 0.021652472, 0.045019544, -0.017198084, -0.022693911, 0.012306397, 0.010784015, -0.0078097348, -0.0045160954, 0.0042748181, 0.0015519393, -0.0019107203, -0.00040883876, 0.00060775794, 0.00011397832, -6.6123548e-005, -9.8933455e-005, -5.3452188e-005, 0.00010586336, 1.7297201e-005, -7.2675672e-005, 2.6452607e-005, 2.2868742e-005, -3.2830067e-005, 1.0602014e-005, 1.4217352e-005, -1.7280266e-005, 4.3752764e-006, 7.427383e-006, -1.0045807e-005, 3.4288134e-006, 5.1028515e-006, -6.757326e-006, 1.6986728e-006, 3.4206657e-006, -4.2670334e-006, 1.1842062e-006, 2.3712818e-006, -2.9824249e-006, 6.9474288e-007, 1.685139e-006, -2.0360473e-006, 4.9361831e-007, 1.2185021e-006, -1.4824969e-006, 3.1790474e-007, 9.0422391e-007, -1.0675471e-006, 0}},
                               {"sym2", new[]{0.34150635, 0.59150635, 0.15849365, -0.091506351}},
                               {"sym3", new[]{0.2352336, 0.57055846,  0.3251825, -0.095467208, -0.060416104, 0.02490875}},
                               {"sym4", new[]{0.022785173,  -0.0089123507, -0.070158812, 0.21061727, 0.56832912, 0.35186953, -0.020955483, -0.053574451}},
                               {"sym5", new[]{0.013816076, -0.01492125, -0.12397568, 0.011739462, 0.44829082, 0.51152648, 0.14099535, -0.027672093, 0.020873432, 0.019327398}},
                               {"sym6", new[]{-0.0055159338, 0.001249961, 0.031625281, -0.014891876, -0.051362485,  0.23895219,  0.55694639,  0.34722899, -0.034161561, -0.083431608, 0.0024683062,  0.01089235}},
                               {"sym7", new[]{0.0072606974, 0.0028356713, -0.076231936, -0.099028353,   0.20409197,   0.54289135, 0.3790813,   0.01233283, -0.035039146,  0.048007384,  0.021577726,  -0.0089352158, -0.00074061296, 0.0018963293}},
                               {"sym8", new[]{0.0013363967, -0.00021419715, -0.010572843, 0.0026931944, 0.034745233, -0.019246761, -0.036731254, 0.25769934, 0.54955332, 0.34037267, -0.043326808, -0.10132433, 0.0053793059, 0.022411812, -0.00038334545, -0.0023917293}}
                           };
        }

        /// <summary>
        /// Retrieves a mother-wavelet using its name
        /// </summary>
        /// <param name="name">Mother-wavelet name. Examples: (db4, haar, coif1, meyer, sym3) </param>
        /// <returns></returns>
        public static MotherWavelet GetWaveletFromName(string name)
        {
            name = name.ToLower();
            if (Regex.Match(name, "[?d|^daub][0-9]+").Length > 0)
            {
                name = name.Replace("d", "db").Replace("dbaub", "db").Replace("dbb", "db");
            }
            if (!Wavelets.ContainsKey(name))
            {
                return null;
            }
            var wavelet = Wavelets[name];
            return new MotherWavelet(name, wavelet);
        }
    }
}