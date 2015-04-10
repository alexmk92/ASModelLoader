using System;
using System.Runtime.InteropServices;

namespace ASLoader.math
{
    public class ASVECTOR3
    {
        // Could make a getter for these... in general the w component
        // is ignored, it only exists for satisfying matrix mult
        public double[] points = new double[3];

        /// <summary>
        /// Constructor for a new Vector 4
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public ASVECTOR3(double x, double y, double z)
        {
            points[0] = x;
            points[1] = y;
            points[2] = z;
        }

        /// <summary>
        /// Initialise a zeroed vector
        /// </summary>
        public ASVECTOR3()
        {
            points[0] = 0;
            points[1] = 0;
            points[2] = 0;
        }

        /// <summary>
        /// Initialise a new vector with a vector
        /// </summary>
        /// <param name="vec"></param>
        public ASVECTOR3(ASVECTOR3 vec)
        {
            points[0] = vec.points[0];
            points[1] = vec.points[1];
            points[2] = vec.points[2];
        }

        /// <summary>
        /// Return a new identity matrix.
        /// </summary>
        /// <returns></returns>
        public void OneVector()
        {
            points[0] = 1.0f;
            points[1] = 1.0f;
            points[2] = 1.0f;
        }

        /// <summary>
        /// Returns a zeroed matrix
        /// </summary>
        /// <returns></returns>
        public void ZeroVector()
        {
            points[0] = 0.0f;
            points[1] = 0.0f;
            points[2] = 0.0f;
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
            return (double)Math.Sqrt(points[0] * points[0] + points[1] * points[1] + points[2] * points[2]);
        }

        /// <summary>
        /// Finds the cross product between two vectors (times rows by cols)
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        /// <returns></returns>
        public ASVECTOR3 CrossProduct(ASVECTOR3 v)
        {
            return new ASVECTOR3(points[1] * v.points[2] - points[2] * v.points[1],
                                 points[2] * v.points[0] - points[0] * v.points[2],
                                 points[0] * v.points[1] - points[1] * v.points[0]
                                );
        }

        /// <summary>
        /// Gets the X angle between two vectors
        /// </summary>
        /// <param name="vecA"></param>
        /// <returns></returns>
        public double GetAngleX()
        {
            var vx = new ASVECTOR3(1, 0, 0);
            double angle = ScalarProduct(vx) / GetMagnitude();
            return Math.Acos(angle);
        }

        /// <summary>
        /// Gets the Y angle between two vectors
        /// </summary>
        /// <param name="vecA"></param>
        /// <returns></returns>
        public double GetAngleY()
        {
            var vy = new ASVECTOR3(0, 1, 0);
            double angle = ScalarProduct(vy) / GetMagnitude();
            return Math.Acos(angle);
        }

        /// <summary>
        /// Gets the Z angle between two vectors
        /// </summary>
        /// <param name="vecA"></param>
        /// <returns></returns>
        public double GetAngleZ()
        {
            var vz = new ASVECTOR3(0, 0, 1);
            double angle = ScalarProduct(vz) / GetMagnitude();
            return Math.Acos(angle);
        }

        /// <summary>
        /// Gets the horizontal angle between two vectors
        /// </summary>
        /// <returns></returns>
        public double GetHorizontalAngle()
        {
            // Catch the case where we have an invalid horizontal angle (x and y planes are at origin)
            if (points[0] == 0 && points[1] == 0 && points[2] != 0)
                return 0;
            // Calculate the horizontal angle
            var normX = new ASVECTOR3(1, 0, 0);
            var normZ = new ASVECTOR3(0, 0, 1);

            var scalarX = ScalarProduct(normX);
            var scalarZ = ScalarProduct(normZ);

            var vecX = new ASVECTOR3(scalarX, 0, 0);
            var vecZ = new ASVECTOR3(0, 0, scalarZ);

            var vecXZ = new ASVECTOR3();

            vecXZ.AddToVector(vecX);
            vecXZ.AddToVector(vecZ);
            vecXZ.Normalise();

            double angle = Math.Acos(normZ.ScalarProduct(vecXZ));
            if (vecX.points[0] < 0)
                return Math.PI * 2.0f - angle;
            else
                return angle;
        }

        /// <summary>
        /// Scale the vector by a factor and return it
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public ASVECTOR3 ScaleVector(double scalar)
        {
            points[0] *= scalar;
            points[1] *= scalar;
            points[2] *= scalar;

            return this;
        }

        /// <summary>
        /// Rescales a vector after it has been transformed
        /// </summary>
        /// <returns></returns>
        public ASVECTOR3 ScaleVector()
        {
            ASVECTOR3 output = new ASVECTOR3();

            for (int i = 0; i < 3; i++)
                output.points[i] = points[i] / 1;

            return output;
        }

        /// <summary>
        /// Adds the x,y,z components of two vectors together
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void AddToVector(ASVECTOR3 vecB)
        {
            points[0] += vecB.points[0];
            points[1] += vecB.points[1];
            points[2] += vecB.points[2];
        }

        /// <summary>
        /// Substracts the x,y,z components of two vectors from one another
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void MinusFromVector(ASVECTOR3 vecB)
        {
            points[0] -= vecB.points[0];
            points[1] -= vecB.points[1];
            points[2] -= vecB.points[2];
        }

        /// <summary>
        /// Divides the x,y,z components of two vectors by eachother
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void DivideVector(ASVECTOR3 vecB)
        {
            points[0] /= vecB.points[0];
            points[1] /= vecB.points[1];
            points[2] /= vecB.points[2];
        }

        /// <summary>
        /// Multiplies the x,y,z components of vectors together
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        public void MultiplyVector(ASVECTOR3 vecB)
        {
            points[0] *= vecB.points[0];
            points[1] *= vecB.points[1];
            points[2] *= vecB.points[2];
        }

        /// <summary>
        /// Given vector v, check if the normalised length of the vector is
        /// zero, if so return a zeroed ASVECTOR3 other return the
        /// normalised vector by dividing the vector by the length scalar.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public ASVECTOR3 Normalise()
        {
            return this.ScaleVector(1.0 / GetMagnitude());
        }

        /// <summary>
        /// Rotate around the X Plane by a given deg
        /// We have to do all of our multiplication before assigning, if we 
        /// assigned to value z and y on the respective first two lines, then the
        /// value would be changed before computing the next.
        /// </summary>
        /// <param name="deg"></param>
        public void RotateX(double deg)
        {
            var newZ = (points[2] * Math.Cos(deg) - points[1] * Math.Sin(deg));
            var newY = (points[2] * Math.Sin(deg) + points[1] * Math.Cos(deg));

            points[2] = newZ;
            points[1] = newY;
        }

        /// <summary>
        /// Rotate around the Y plane by a given deg
        /// </summary>
        /// <param name="deg"></param>
        public void RotateY(double deg)
        {
            var newX = (points[0] * Math.Cos(deg) - points[2] * Math.Sin(deg));
            var newZ = (points[0] * Math.Sin(deg) + points[2] * Math.Cos(deg));

            points[0] = newX;
            points[2] = newZ;
        }

        /// <summary>
        /// Rotate around the Z plane by a given deg
        /// </summary>
        /// <param name="deg"></param>
        public void RotateZ(double deg)
        {
            var newX = (points[0] * Math.Cos(deg) - points[1] * Math.Sin(deg));
            var newY = (points[0] * Math.Sin(deg) + points[1] * Math.Cos(deg));

            points[0] = newX;
            points[1] = newY;
        }

        /// <summary>
        /// Rotates the mesh around some plane
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="deg"></param>
        public void RotateAroundOrigin(ASVECTOR3 axis, double deg)
        {
            double xPlane = axis.GetHorizontalAngle();
            double yPlane = axis.GetAngleY();

            // Rotate the viewer about the X,Y plane to give the illusion of smooth rotation
            this.RotateY(-xPlane);
            this.RotateX(-yPlane);
            this.RotateY(deg);
            this.RotateX(yPlane);
            this.RotateY(xPlane);
        }

        /// <summary>
        /// Transform the vector by a matrix
        /// </summary>
        /// <param name="m"></param>
        public ASVECTOR3 TransformVector(ASMATRIX4 m)
        {
            var newPoint = new ASVECTOR3();

            // Multiply rows by cols to get the new vector
            for (var col = 0; col < 3; col++)
            {
                double total = 0;
                for (var row = 0; row < 3; row++)
                    total = total + points[row] * m.Matrix[col].Points[row];
            }

            return newPoint;
        }

        /// <summary>
        /// Returns the product of vector A and B
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        /// <returns></returns>
        public double ScalarProduct(ASVECTOR3 v)
        {
            return (points[0] * v.points[0] + points[1] * v.points[1] + points[2] * v.points[2]);
        }
    }
}
