using System;
using System.Runtime.InteropServices;

namespace ASLoader.math
{
    /// <summary>
    /// Represent a homogenous coordinate in the scope of this system
    /// </summary>
    public class ASVECTOR4
    {
        // Could make a getter for these... in general the w component
        // is ignored, it only exists for satisfying matrix mult
        public double[] Points = new double[4];

        // OPERATOR OVERLOADS

        /// <summary>
        /// Minus the components of vector A from vector B to get edge 3
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static ASVECTOR4 operator -(ASVECTOR4 v1, ASVECTOR4 v2)
        {
            var newVec = new ASVECTOR4(v1.Points[0] - v2.Points[0], v1.Points[1] - v2.Points[1],
                                       v1.Points[2] - v2.Points[2]);
            return newVec;
        }

        /// <summary>
        /// Finds the cross product between two vectors (times rows by cols)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static ASVECTOR4 operator *(ASVECTOR4 v1, ASVECTOR4 v2)
        {
            return new ASVECTOR4( v1.Points[1] * v2.Points[2] - v1.Points[2] * v2.Points[1],
                                  v1.Points[2] * v2.Points[0] - v1.Points[0] * v2.Points[2],
                                  v1.Points[0] * v2.Points[1] - v1.Points[1] * v2.Points[0]
                                );
        }

        /// <summary>
        /// Transform the matrix by a point
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static ASVECTOR4 operator *(ASMATRIX4 m, ASVECTOR4 p)
        {
            var x = p.Points[0] * m.Matrix[0].Points[0] +
                    p.Points[1] * m.Matrix[0].Points[1] +
                    p.Points[2] * m.Matrix[0].Points[2];
            var y = p.Points[0] * m.Matrix[1].Points[0] +
                    p.Points[1] * m.Matrix[1].Points[1] +
                    p.Points[2] * m.Matrix[1].Points[2];
            var z = p.Points[0] * m.Matrix[2].Points[0] +
                    p.Points[1] * m.Matrix[2].Points[1] +
                    p.Points[2] * m.Matrix[2].Points[2];

            return new ASVECTOR4(x, y, z, 1);
        }

        /// <summary>
        /// Constructor for a new Vector 4
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public ASVECTOR4(double x, double y, double z, double w = 1)
        {
            Points[0] = x;
            Points[1] = y;
            Points[2] = z;
            Points[3] = w;
        }

        /// <summary>
        /// Initialise a zeroed vector
        /// </summary>
        public ASVECTOR4()
        {
            Points[0] = 0;
            Points[1] = 0;
            Points[2] = 0;
            Points[3] = 1;
        }

        /// <summary>
        /// Initialise a new vector with a vector
        /// </summary>
        /// <param name="vec"></param>
        public ASVECTOR4(ASVECTOR4 vec)
        {
            Points[0] = vec.Points[0];
            Points[1] = vec.Points[1];
            Points[2] = vec.Points[2];
            Points[3] = vec.Points[3];
        }

        /// <summary>
        /// Return a new identity matrix.
        /// </summary>
        /// <returns></returns>
        public void OneVector()
        {
            Points[0] = 1.0f;
            Points[1] = 1.0f;
            Points[2] = 1.0f;
            Points[3] = 1.0f;
        }

        /// <summary>
        /// Returns a zeroed matrix
        /// </summary>
        /// <returns></returns>
        public void ZeroVector()
        {
            Points[0] = 0.0f;
            Points[1] = 0.0f;
            Points[2] = 0.0f;
            Points[3] = 1.0f;
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
            return Math.Sqrt(Points[0] * Points[0] + Points[1] * Points[1] + Points[2] * Points[2]);
        }

        /// <summary>
        /// Adds the x,y,z components of two vectors together
        /// </summary>
        /// <param name="vecB"></param>
        public void AddToVector(ASVECTOR4 vecB)
        {
            Points[0] += vecB.Points[0];
            Points[1] += vecB.Points[1];
            Points[2] += vecB.Points[2];
        }

        /// <summary>
        /// Substracts the x,y,z components of two vectors from one another
        /// </summary>
        /// <param name="vecB"></param>
        public void MinusFromVector(ASVECTOR4 vecB)
        {
            Points[0] -= vecB.Points[0];
            Points[1] -= vecB.Points[1];
            Points[2] -= vecB.Points[2];
        }

        /// <summary>
        /// Divides the x,y,z components of two vectors by eachother
        /// </summary>
        /// <param name="vecB"></param>
        public void DivideVector(ASVECTOR4 vecB)
        {
            Points[0] /= vecB.Points[0];
            Points[1] /= vecB.Points[1];
            Points[2] /= vecB.Points[2];
        }

        /// <summary>
        /// Multiplies the x,y,z components of vectors together
        /// </summary>
        /// <param name="vecB"></param>
        public void MultiplyVector(ASVECTOR4 vecB)
        {
            Points[0] *= vecB.Points[0];
            Points[1] *= vecB.Points[1];
            Points[2] *= vecB.Points[2];
        }

        /// <summary>
        /// Multiplies the x,y,z components of vector by a given scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public ASVECTOR4 MultiplyVector(double scalar)
        {
            Points[0] *= scalar;
            Points[1] *= scalar;
            Points[2] *= scalar;

            return this;
        }

        /// <summary>
        /// Given vector v, check if the normalised length of the vector is
        /// zero, if so return a zeroed ASVECTOR4 other return the
        /// normalised vector by dividing the vector by the length scalar.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public ASVECTOR4 Normalise()
        {
            var len = GetMagnitude();
            if (len.Equals(0.0d))
                len = 1.0d;

            this.Points[0] /= len;
            this.Points[1] /= len;
            this.Points[2] /= len;

            return this;
        }

        /// <summary>
        /// Transform the vector by a matrix
        /// </summary>
        /// <param name="m"></param>
        public ASVECTOR4 TransformVector(ASMATRIX4 m)
        {
            return m*this;
        }

        /// <summary>
        /// Rescales the point to a valid unit so we can draw it to the screen
        /// </summary>
        /// <returns></returns>
        public ASVECTOR4 Rescale()
        {
            var newPoint = new ASVECTOR4();
            for (var i = 0; i < 4; i++)
                newPoint.Points[i] = Points[i] / Points[3];

            return newPoint;
        }

        /// <summary>
        /// Returns the product of vector A and B
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double ScalarProduct(ASVECTOR4 v)
        {
            return (Points[0] * v.Points[0] + Points[1] * v.Points[1] + Points[2] * v.Points[2]);
        }
    }
}
