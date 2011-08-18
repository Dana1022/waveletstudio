﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WaveletStudio.Wavelet
{
    /// <summary>
    /// Provides common mother wavelets, like Daubechies, Haar, etc.
    /// </summary>
    public static class CommonMotherWavelets
    {
        /// <summary>
        /// List of wavelets. 
        /// </summary>
        public static Dictionary<string, double[]> Wavelets { get; private set; }

        private static readonly Dictionary<string, MotherWavelet> MotherWaveletsCache;

        static CommonMotherWavelets()
        {
            MotherWaveletsCache = new Dictionary<string, MotherWavelet>();
            Wavelets = new Dictionary<string, double[]>
                           {
                               {"coif1", new[]{-0.051429728471, 0.238929728471, 0.602859456942, 0.272140543058, -0.051429728471, -0.011070271529000}},
                               {"coif2", new[]{0.011587596739, -0.02932013798, -0.04763959031, 0.273021046535, 0.574682393857, 0.294867193696, -0.054085607092, -0.042026480461, 0.016744410163, 0.003967883613, -0.001289203356, -0.000509505399000}},
                               {"coif3", new[]{-0.002682418671, 0.005503126709, 0.016583560479, -0.046507764479, -0.04322076356, 0.286503335274, 0.56128525687, 0.302983571773, -0.050770140755, -0.058196250762, 0.024434094321, 0.011229240962, -0.006369601011, -0.001820458916, 0.000790205101, 0.000329665174, -0.000050192775, -0.000024465734000}},
                               {"coif4", new[]{0.000630961046, -0.001152224852, -0.005194524026, 0.011362459244, 0.018867235378, -0.057464234429, -0.039652648517, 0.293667390895, 0.553126452562, 0.307157326198, -0.047112738865, -0.068038127051, 0.027813640153, 0.017735837438, -0.010756318517, -0.004001012886, 0.002652665946, 0.000895594529, -0.000416500571, -0.000183829769, 0.000044080354, 0.000022082857, -0.000002304942, -0.000001262175000}},
                               {"coif5", new[]{-0.0001499638, 0.0002535612, 0.0015402457, -0.0029411108, -0.0071637819, 0.0165520664, 0.0199178043, -0.0649972628, -0.0368000736, 0.2980923235, 0.5475054294, 0.309706849, -0.0438660508, -0.0746522389, 0.0291958795, 0.023110777, -0.0139736879, -0.00648009, 0.0047830014, 0.0017206547, -0.0011758222, -0.000451227, 0.0002137298, 0.0000993776, -0.0000292321, -0.000015072, 0.0000026408, 0.0000014593, -0.0000001184, -0.000000067300000}},
                               {"db2", new[]{0.341506350946221, 0.591506350945867, 0.158493649053779, -0.091506350945867}},
                               {"db3", new[]{0.235233603892705, 0.570558457917308, 0.32518250026371, -0.09546720778426, -0.060416104155354, 0.024908749865891}},
                               {"db4", new[]{0.162901714025618, 0.505472857545651, 0.446100069123194, -0.019787513117909, -0.132253583684369, 0.021808150237385, 0.023251800535557, -0.007493494665127}},
                               {"db5", new[]{0.11320949129173, 0.426971771352711, 0.512163472130156, 0.097883480673754, -0.17132835769133, -0.022800565942047, 0.054851329321077, -0.004413400054325, -0.008895935050926, 0.002358713969201}},
                               {"db6", new[]{0.078871216001434, 0.349751907037568, 0.531131879941213, 0.222915661465051, -0.159993299445874, -0.091759032030033, 0.068944046487197, 0.019461604853964, -0.022331874165475, 0.000391625576035, 0.003378031181505, -0.000761766902584}},
                               {"db7", new[]{0.055049715372848, 0.280395641813038, 0.515574245818332, 0.33218624110566, -0.101756911231733, -0.158417505640544, 0.050423232504853, 0.057001722579857, -0.026891226294856, -0.011719970782348, 0.008874896189617, 0.000303757497757, -0.001273952359061, 0.000250113426579}},
                               {"db8", new[]{0.03847781105406, 0.221233623576241, 0.477743075214377, 0.413908266211663, -0.01119286766665, -0.200829316391107, 0.000334097046282, 0.091038178423454, -0.012281950523003, -0.031175103325331, 0.009886079648084, 0.006184422409538, -0.003443859628128, -0.000277002274213, 0.000477614855332, -0.000083068630599}},
                               {"db9", new[]{0.02692517479416, 0.172417151924713, 0.427674532170283, 0.464772857172778, 0.09418477475112, -0.207375880896283, -0.068476774510903, 0.105034171137136, 0.021726337729904, -0.047823632058819, 0.000177446406732, 0.015812082926137, -0.003339810113241, -0.003027480287151, 0.001306483640179, 0.00016290733601, -0.000178164879547, 0.000027822756793}},
                               {"db10", new[]{0.018858578796396, 0.133061091396866, 0.372787535742662, 0.4868140553661, 0.198818870884399, -0.17666810089647, -0.138554939359932, 0.090063724266658, 0.065801493550702, -0.050483285598005, -0.020829624043846, 0.023484907048409, 0.002550218483933, -0.007589501167679, 0.000986662682442, 0.001408843294964, -0.000484973919956, -0.000082354502954, 0.000066177183199, -0.000009379207888}},
                               {"haar", new[]{0.5, 0.5}},
                               {"dmeyer", new[]{-0.00000106754713, 0.00000090422391, 0.00000031790474, -0.00000148249686, 0.00000121850207, 0.00000049361831, -0.00000203604729, 0.00000168513902, 0.00000069474288, -0.00000298242491, 0.00000237128175, 0.00000118420622, -0.00000426703335, 0.00000342066573, 0.00000169867277, -0.000006757326, 0.00000510285152, 0.00000342881336, -0.00001004580737, 0.00000742738297, 0.00000437527643, -0.0000172802656, 0.00001421735152, 0.00001060201359, -0.00003283006737, 0.00002286874237, 0.00002645260683, -0.00007267567236, 0.0000172972015, 0.00010586335588, -0.0000534521877, -0.00009893345543, -0.00006612354762, 0.0001139783219, 0.00060775793536, -0.00040883876416, -0.0019107202819, 0.00155193926157, 0.00427481806225, -0.00451609544333, -0.00780973483285, 0.01078401534427, 0.01230639736499, -0.02269391137934, -0.01719808438302, 0.04501954358581, 0.02165247163319, -0.09383060025865, -0.02478286152969, 0.31402235238643, 0.52591095141626, 0.31402235238643, -0.024782861, -0.09383060025865, 0.02165247163319, 0.04501954358581, -0.01719808438302, -0.02269391137934, 0.01230639736499, 0.01078401534427, -0.00780973483285, -0.00451609544333, 0.00427481806225, 0.00155193926157, -0.0019107202819, -0.00040883876416, 0.00060775793536, 0.0001139783219, -0.00006612354762, -0.00009893345543, -0.0000534521877, 0.00010586335588, 0.0000172972015, -0.00007267567236, 0.00002645260683, 0.00002286874237, -0.00003283006737, 0.00001060201359, 0.00001421735152, -0.0000172802656, 0.00000437527643, 0.00000742738297, -0.00001004580737, 0.00000342881336, 0.00000510285152, -0.000006757326, 0.00000169867277, 0.00000342066573, -0.00000426703335, 0.00000118420622, 0.00000237128175, -0.00000298242491, 0.00000069474288, 0.00000168513902, -0.00000203604729, 0.00000049361831, 0.00000121850207, -0.00000148249686, 0.00000031790474, 0.00000090422391, -0.00000106754713, 0}},
                               {"sym2", new[]{0.341506350946439, 0.591506350946245, 0.158493649053881, -0.091506350945926}},
                               {"sym3", new[]{0.235233603892705, 0.570558457917308, 0.32518250026371, -0.09546720778426, -0.060416104155354, 0.024908749865891}},
                               {"sym4", new[]{0.022785172948, -0.00891235072085, -0.0701588120895, 0.210617267102, 0.568329121705, 0.351869534328, -0.02095548256255, -0.053574450709000}},
                               {"sym5", new[]{0.013816076478928, -0.014921249934381, -0.123975681306754, 0.011739461568074, 0.448290824190919, 0.511526483446049, 0.140995348427289, -0.027672093058357, 0.020873432210793, 0.019327397977440}},
                               {"sym6", new[]{-0.00551593375469, 0.001249961046393, 0.031625281329941, -0.014891875649222, -0.051362484930904, 0.238952185666053, 0.556946391963958, 0.347228986478351, -0.034161560793236, -0.083431607705844, 0.00246830618592, 0.010892350163280}},
                               {"sym7", new[]{0.007260697381013, 0.002835671342875, -0.076231935948139, -0.099028353403681, 0.204091969862873, 0.542891354905994, 0.379081300982694, 0.012332829744323, -0.035039145611064, 0.048007383967838, 0.021577726291039, -0.008935215825566, -0.000740612957301, 0.001896329267103}},
                               {"sym8", new[]{0.001336396696403, -0.000214197150123, -0.010572843264181, 0.00269319437688, 0.034745232955587, -0.019246760631665, -0.036731254380384, 0.257699335186535, 0.549553315269009, 0.340372673594386, -0.043326807702822, -0.101324327642817, 0.00537930587524, 0.02241181152181, -0.000383345448113, -0.002391729255746}}
                           };
        }

        /// <summary>
        /// Gets the Mother Wavelet object base on it name. Returns null if the name is not found.
        /// </summary>
        /// <param name="name">The name of the wavelet. Examples: db4, haar, sym2, dmeyer, coif3</param>
        /// <returns></returns>
        public static MotherWavelet GetWaveletFromName(string name)
        {
            name = name.ToLower();
            if (Regex.Match(name, "[?d|^daub][0-9]+").Length > 0)
            {
                name = name.Replace("d", "db").Replace("dbaub", "db").Replace("dbb", "db");
            }
            if (!MotherWaveletsCache.ContainsKey(name))
            {
                if (!Wavelets.ContainsKey(name))
                {
                    return null;
                }
                var wavelet = new MotherWavelet(name, Wavelets[name]);
                wavelet.CalculateFilters();
                MotherWaveletsCache.Add(name, wavelet);
                return wavelet;
            }
            return MotherWaveletsCache[name];
        }
    }
}