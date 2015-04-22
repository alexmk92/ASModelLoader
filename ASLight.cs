using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASLoader.math;

namespace ASLoader
{
    class ASLight
    {
        /// <summary>
        /// ASVECTOR4's to represent each of the different color components
        /// for a light, we use an ASVECTOR4 as I haven't currently written 
        /// an ASVECTOR3, so we will ignore the W component (defaults as 1)
        /// </summary>
        private ASVECTOR4 ambient, specular, diffuse, position;

        private double ambientIntensity, diffuseInensity, specularIntensity, n, k;

        /// <summary>
        /// Create anew ASLight object 
        /// </summary>
        /// <param name="ambient"></param>
        /// <param name="specular"></param>
        /// <param name="diffuse"></param>
        public ASLight(ASVECTOR4 ambient, ASVECTOR4 specular, ASVECTOR4 diffuse, ASVECTOR4 position)
        {
            this.ambient  = ambient;
            this.specular = specular;
            this.diffuse  = diffuse;
            this.position = position;
        }

        /// <summary>
        /// Blank light constructor, this will be used to create a white light
        /// </summary>
        public ASLight()
        {
            ambient =  new ASVECTOR4();
            ambient.OneVector();
            specular = new ASVECTOR4();
            specular.OneVector();
            diffuse  = new ASVECTOR4();
            diffuse.OneVector();
            position = new ASVECTOR4(0, 0, 0, 0);
        }

        public void SetAmbient(ASVECTOR4 value)
        {
            ambient = value;
        }

        public void SetSpecular(ASVECTOR4 value)
        {
            specular = value;
        }

        public void SetDiffuse(ASVECTOR4 value)
        {

            diffuse = value;
        }

        public void SetPosition(ASVECTOR4 value)
        {
            position = value;
        }
    }
}
