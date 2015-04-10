using System;
using System.Runtime.InteropServices;

namespace ASLoader.math
{
    public class ASVECTOR2
    {
        // Could make a getter for these...
        public double x, y;

        /// <summary>
        /// Constructor for a new Vector 4
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public ASVECTOR2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Initialise a zeroed vector
        /// </summary>
        public ASVECTOR2()
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Initialise a new vector with a vector
        /// </summary>
        /// <param name="vec"></param>
        public ASVECTOR2(ASVECTOR2 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        /// <summary>
        /// Return a new identity matrix.
        /// </summary>
        /// <returns></returns>
        public void OneVector()
        {
            this.x = 1.0f;
            this.y = 1.0f;
        }

        /// <summary>
        /// Returns a zeroed matrix
        /// </summary>
        /// <returns></returns>
        public void ZeroVector()
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        /// <summary>
        /// Normalise the vector so that its value lies between
        /// 0 and 1, done by dividing vector by its magnitude
        /// to scale the vector down without effecting its direction
        /// 
        /// This is done by finding the sqrt of all the vectors components.
        /// </summary>
        /// <returns></returns>
        public double GetMagnitude()
        {
            return (double)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Gets the X angle between two vectors
        /// </summary>
        /// <param name="vecA"></param>
        /// <returns></returns>
        public double GetAngleX()
        {
            var vx = new ASVECTOR2(1, 0);
            var vn = new ASVECTOR2(this);
            vn.Normalise();

            double angle = Math.Acos(vx.ScalarProduct(vn));

            if (vn.y < 0)
                return Math.PI * 2.0 - angle;

            return angle;
        }

        /// <summary>
        /// Gets the Y angle between two vectors
        /// </summary>
        /// <param name="vecA"></param>
        /// <returns></returns>
        public double GetAngleY()
        {
            var vy = new ASVECTOR2(0, 1);
            var vn = new ASVECTOR2(this);
            vn.Normalise();

            double angle = Math.Acos(vy.ScalarProduct(vn));

            if (vn.x > 0)
                return Math.PI * 2.0 - angle;

            return angle;
        }

        /// <summary>
        /// Scale the vector by a factor and return it
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public ASVECTOR2 ScaleVector(double scalar)
        {
            x *= scalar;
            y *= scalar;

            return this;
        }

        /// <summary>
        /// Adds the x,y,z components of two vectors together
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void AddToVector(ASVECTOR2 vecB)
        {
            x += vecB.x;
            y += vecB.y;
        }

        /// <summary>
        /// Substracts the x,y,z components of two vectors from one another
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void MinusFromVector(ASVECTOR2 vecB)
        {
            x -= vecB.x;
            y -= vecB.y;
        }

        /// <summary>
        /// Divides the x,y,z components of two vectors by eachother
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void DivideVector(ASVECTOR2 vecB)
        {
            x /= vecB.x;
            y /= vecB.y;
        }

        /// <summary>
        /// Multiplies the x,y,z components of vectors together
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void MultiplyVector(ASVECTOR2 vecB)
        {
            x *= vecB.x;
            y *= vecB.y;
        }

        /// <summary>
        /// Given vector v, check if the normalised length of the vector is
        /// zero, if so return a zeroed ASVECTOR2 other return the
        /// normalised vector by dividing the vector by the length scalar.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public ASVECTOR2 Normalise()
        {
            return this.ScaleVector(1.0 / GetMagnitude());
        }

        /// <summary>
        /// Converts the ASVECTOR2 into an Orthogonal representation of itself
        /// </summary>
        public void ConvertToOrthogonal()
        {
            var tmpX = x;
            this.x = -y;
            this.y = tmpX;
        }

        /// <summary>
        /// Rotates the 2D vector
        /// </summary>
        /// <param name="deg"></param>
        public ASVECTOR2 Rotate(double deg)
        {
            var newX = (x * Math.Cos(deg) - y * Math.Sin(deg));
            var newY = (x * Math.Sin(deg) + y * Math.Cos(deg));

            this.x = newX;
            this.y = newY;

            return this;
        }

        /// <summary>
        /// Returns the product of vector A and B
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        /// <returns></returns>
        public double ScalarProduct(ASVECTOR2 v)
        {
            return (this.x * v.x + this.y * v.y);
        }
    }
}
