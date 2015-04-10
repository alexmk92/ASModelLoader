using System;
using System.Runtime.InteropServices;

namespace ASLoader.math
{
    public class ASVECTOR4
    {
        // Could make a getter for these... in general the w component
        // is ignored, it only exists for satisfying matrix mult
        public double[] Points = new double[4];

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
        /// Finds the cross product between two vectors (times rows by cols)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public ASVECTOR4 CrossProduct(ASVECTOR4 v)
        {
            return new ASVECTOR4(Points[1] * v.Points[2] - Points[2] * v.Points[1],
                                 Points[2] * v.Points[0] - Points[0] * v.Points[2],
                                 Points[0] * v.Points[1] - Points[1] * v.Points[0]
                                );
        }

        /// <summary>
        /// Gets the X angle between two vectors
        /// </summary>
        /// <returns></returns>
        public double GetAngleX()
        {
            var vx = new ASVECTOR4(1, 0, 0);
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
            var vy = new ASVECTOR4(0, 1, 0);
            double angle = ScalarProduct(vy) / GetMagnitude();
            return Math.Acos(angle);
        }

        /// <summary>
        /// Gets the Z angle between two vectors
        /// </summary>
        /// <returns></returns>
        public double GetAngleZ()
        {
            var vz = new ASVECTOR4(0, 0, 1);
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
            if (Math.Abs(Points[0]) <= 0 && Math.Abs(Points[1]) <= 0 && Math.Abs(Points[2]) > 0)
                return 0;
            // Calculate the horizontal angle
            var normX = new ASVECTOR4(1, 0, 0);
            var normZ = new ASVECTOR4(0, 0, 1);

            var scalarX = ScalarProduct(normX);
            var scalarZ = ScalarProduct(normZ);

            var vecX = new ASVECTOR4(scalarX, 0, 0);
            var vecZ = new ASVECTOR4(0, 0, scalarZ);

            var vecXZ = new ASVECTOR4();

            vecXZ.AddToVector(vecX);
            vecXZ.AddToVector(vecZ);
            vecXZ.Normalise();

            var angle = Math.Acos(normZ.ScalarProduct(vecXZ));
            if (vecX.Points[0] < 0)
                return Math.PI * 2.0f - angle;

            return angle;
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
            return this.MultiplyVector(1.0 / GetMagnitude());
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
            var newZ = (Points[2] * Math.Cos(deg) - Points[1] * Math.Sin(deg));
            var newY = (Points[2] * Math.Sin(deg) + Points[1] * Math.Cos(deg));

            Points[2] = newZ;
            Points[1] = newY;
        }

        /// <summary>
        /// Rotate around the Y plane by a given deg
        /// </summary>
        /// <param name="deg"></param>
        public void RotateY(double deg)
        {
            var newX = (Points[0] * Math.Cos(deg) - Points[2] * Math.Sin(deg));
            var newZ = (Points[0] * Math.Sin(deg) + Points[2] * Math.Cos(deg));

            Points[0] = newX;
            Points[2] = newZ;
        }

        /// <summary>
        /// Rotate around the Z plane by a given deg
        /// </summary>
        /// <param name="deg"></param>
        public void RotateZ(double deg)
        {
            var newX = (Points[0] * Math.Cos(deg) - Points[1] * Math.Sin(deg));
            var newY = (Points[0] * Math.Sin(deg) + Points[1] * Math.Cos(deg));

            Points[0] = newX;
            Points[1] = newY;
        }

        /// <summary>
        /// Rotates the mesh around some plane
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="deg"></param>
        public void RotateAroundOrigin(ASVECTOR4 axis, double deg)
        {
            double xPlane = axis.GetHorizontalAngle();
            double yPlane = axis.GetAngleY();

            // Rotate the viewer about the X,Y plane to give the illusion of smooth rotation
            RotateY(-xPlane);
            RotateX(-yPlane);
            RotateY(deg);
            RotateX(yPlane);
            RotateY(xPlane);
        }

        /// <summary>
        /// Transform the vector by a matrix
        /// </summary>
        /// <param name="m"></param>
        public ASVECTOR4 TransformVector(ASMATRIX4 m)
        {
            var newPoint = new ASVECTOR4();

            // Multiply the matrix by the vector
            for (var col = 0; col < 4; col++)
            {
                double total = 0;
                for (var row = 0; row < 4; row++)
                    total = total + Points[row] * m.Matrix[col].Points[row];

                newPoint.Points[col] = total;
            }

            return newPoint;
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
