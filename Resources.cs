using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Propertiesa
    {
        using System;
    using System.Windows.Media.Imaging;


    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        internal class Resources
        {

            private static global::System.Resources.ResourceManager resourceMan;

            private static global::System.Globalization.CultureInfo resourceCulture;

            [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            internal Resources()
            {
            }

            /// <summary>
            ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
            /// </summary>
            [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
            internal static global::System.Resources.ResourceManager ResourceManager
            {
                get
                {
                    if (object.ReferenceEquals(resourceMan, null))
                    {
                        global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Endless_Development_Project_Studio.Properties.Resources", typeof(Resources).Assembly);
                        resourceMan = temp;
                    }
                    return resourceMan;
                }
            }

            /// <summary>
            ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
            ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
            /// </summary>
            [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
            internal static global::System.Globalization.CultureInfo Culture
            {
                get
                {
                    return resourceCulture;
                }
                set
                {
                    resourceCulture = value;
                }
            }

            internal static BitmapImage Listen_Off
            {
                get
                {
                    object obj = ResourceManager.GetObject("Listen_Off", resourceCulture);
                    return ((BitmapImage)(obj));
                }
            }

            internal static System.Drawing.Bitmap Listen_Off_Small
            {
                get
                {
                    object obj = ResourceManager.GetObject("Listen_Off_Small", resourceCulture);
                    return ((System.Drawing.Bitmap)(obj));
                }
            }

            internal static BitmapImage Listen_On
            {
                get
                {
                    object obj = ResourceManager.GetObject("Listen_On", resourceCulture);
                    return ((BitmapImage)(obj));
                }
            }

            internal static System.Drawing.Bitmap Listen_On_Small
            {
                get
                {
                    object obj = ResourceManager.GetObject("Listen_On_Small", resourceCulture);
                    return ((System.Drawing.Bitmap)(obj));
                }
            }

            internal static BitmapImage Speak_Off
            {
                get
                {
                    object obj = ResourceManager.GetObject("Speak_Off", resourceCulture);
                    return ((BitmapImage)(obj));
                }
            }

            internal static System.Drawing.Bitmap Speak_Off_Small
            {
                get
                {
                    object obj = ResourceManager.GetObject("Speak_Off_Small", resourceCulture);
                    return ((System.Drawing.Bitmap)(obj));
                }
            }

            internal static BitmapImage Speak_On
            {
                get
                {
                    object obj = ResourceManager.GetObject("Speak_On", resourceCulture);
                    return ((BitmapImage)(obj));
                }
            }

            internal static System.Drawing.Bitmap Speak_On_Small
            {
                get
                {
                    object obj = ResourceManager.GetObject("Speak_On_Small", resourceCulture);
                    return ((System.Drawing.Bitmap)(obj));
                }
            }
        }
    }

