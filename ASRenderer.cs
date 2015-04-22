using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ASLoader.math;

namespace ASLoader
{
    /// <summary>
    /// The ASRenderer class is responsible for drawing the model to the 
    /// canvas by using C#'s graphics component
    /// </summary>
    class ASRenderer
    {
        private Graphics    m_graphicsContext;
        private Pen         m_pen;
        private ASWindow    m_window;
        private Panel       m_canvas;
        private ASFace[]    m_meshData;
        private ASVECTOR4[] m_vertices;
        private ASVECTOR4[] m_vNormals;
        public string       m_lastErr;
        private int         m_numVertices;
        private int         m_numFaces;
        private int         m_originX = 200;
        private int         m_originY = 200;
        private double      m_scaleFactor;
        private bool        m_showPoints;
        public bool         m_colorPolys;
        public bool         m_computeNormals;
        private Dictionary<string, int> m_worldInfo;

        private ASMATRIX4   m_perspective;
        private ASMATRIX4   m_translation;
        private ASMATRIX4   m_scaling;
        private ASMATRIX4   m_rotation;

        /// <summary>
        /// Recieves a dictionary containing all data on a model, as well
        /// as a handler to the window we will be drawing too
        /// </summary>
        /// <param name="modelData"></param>
        /// <param name="window">The ASWindow object to draw on</param>
        public ASRenderer(Dictionary<string, object> modelData, ASWindow window)
        {
            // Init the context and window
            m_pen = new Pen(Color.White, 1);
            m_window = window;
            m_canvas = m_window.GetCanvas();

            // Init the matrixes
            m_perspective = new ASMATRIX4();
            m_translation = new ASMATRIX4();
            m_scaling     = new ASMATRIX4();
        }

        /// <summary>
        /// Sets the mesh data to be rendered to the scene.
        /// </summary>
        /// <param name="modelData"></param>
        public void SetMeshData(Dictionary<string, object> modelData)
        {
            // Extract any relevant mesh data and place it in the renderer context
            m_meshData      = modelData["faces"] as ASFace[];
            m_vertices      = modelData["vertices"] as ASVECTOR4[];
            m_numFaces      = Convert.ToInt32(modelData["numFaces"]);
            m_numVertices   = Convert.ToInt32(modelData["numVertices"]);
        }

        /// <summary>
        /// Sets the world info dictionary
        /// </summary>
        public void SetWorldInfo(Dictionary<string, int> info, int originX, int originY, double scaleFactor, bool showPoints)
        {
            m_originX     = originX;
            m_originY     = originY;
            m_scaleFactor = scaleFactor;
            m_worldInfo   = info;
            m_showPoints  = showPoints;
        }

        /// <summary>
        /// Render the mesh to the graphics context
        /// </summary>
        /// <returns></returns>
        public bool RenderMesh()
        {
            InitView();
            TransformMesh();

            try
            {
                // Set the graphics context (this will clear any previous graphics)
                m_graphicsContext = m_canvas.CreateGraphics();

                // Get the collection size
                var tA = new Thread(() => DrawPoint());
                tA.Start();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Draws the point to the canvas using hidden surface removal
        /// </summary>
        private void DrawPoint()
        {
            
            try
            {
                for (var i = 0; i < m_numFaces; i++)
                {
                    var face = m_meshData[i];
                    var faceNormal = new ASVECTOR4();

                    // Check if we will be performing back face culling
                    if (m_computeNormals)
                        faceNormal = face.ComputeFaceNormals();
                    else
                        faceNormal.ZeroVector();

                    // Check what we need to draw
                    if (m_showPoints)
                    {
                        // Draw the face
                        if (faceNormal.Points[2] >= 0.0)
                        {
                            for (var j = 0; j < 2; j++)
                            {
                                m_graphicsContext.DrawLine(m_pen,
                                    (int) face.GetPointAtIndex(j).Points[0] + m_originX,
                                    (int) face.GetPointAtIndex(j).Points[1] + m_originY,
                                    (int) face.GetPointAtIndex(j + 1).Points[0] + m_originX,
                                    (int) face.GetPointAtIndex(j + 1).Points[1] + m_originY
                                    );
                            }
                        }
                    }
                    else
                    {
                        for (var j = 0; j < 2; j++)
                        {
                            m_graphicsContext.DrawRectangle(m_pen, (int)face.GetPointAtIndex(j).Points[0] + m_originX,
                                (int)face.GetPointAtIndex(j).Points[1] + m_originY, 1, 1);
                            m_graphicsContext.DrawRectangle(m_pen, (int)face.GetPointAtIndex(j+1).Points[0] + m_originX,
                                (int)face.GetPointAtIndex(j+1).Points[1] + m_originY, 1, 1);
                        }
                    }

                    // Note this is not Phong - I just wanted to apply some sort of colour after I computed hidden face surface
                    // removal
                    if (m_colorPolys)
                    {
                        // Draw from first point back to last line
                        m_graphicsContext.DrawLine(m_pen,
                            (int)face.GetPointAtIndex(2).Points[0] + m_originX,
                            (int)face.GetPointAtIndex(2).Points[1] + m_originY,
                            (int)face.GetPointAtIndex(0).Points[0] + m_originX,
                            (int)face.GetPointAtIndex(0).Points[1] + m_originY
                            );

                        // Colour polys
                        var pointA = new Point((int)face.GetPointAtIndex(0).Points[0] + m_originX, (int)face.GetPointAtIndex(0).Points[1] + m_originY);
                        var pointB = new Point((int)face.GetPointAtIndex(1).Points[0] + m_originX, (int)face.GetPointAtIndex(1).Points[1] + m_originY);
                        var pointC = new Point((int)face.GetPointAtIndex(2).Points[0] + m_originX, (int)face.GetPointAtIndex(2).Points[1] + m_originY);
                        Point[] points = { pointA, pointB, pointC };


                        // Set the colour
                        var factorX = 1;
                        var factorY = 1;
                        var factorZ = 1;
                        if (faceNormal.Points[0] < 0)
                            factorX = -1;
                        if (faceNormal.Points[1] < 0)
                            factorY = -1;
                        if (faceNormal.Points[2] < 0)
                            factorZ = -1;

                        var color = Color.FromArgb(
                                                    (int)(255 * (faceNormal.Points[0] * factorX)),
                                                    (int)(255 * (faceNormal.Points[1] * factorY)),
                                                    (int)(255 * (faceNormal.Points[2] * factorZ)));
                        var brush = new SolidBrush(color);

                        m_graphicsContext.FillPolygon(brush, points, FillMode.Winding);
                    }
                }
            }
            catch (Exception e)
            {
                
            }

        }

        /// <summary>
        /// Creates the view matrixes
        /// </summary>
        /// <returns></returns>
        private void InitView()
        {
            var info = m_worldInfo;

            var tX = info["translateX"];
            var tY = info["translateY"];
            var tZ = info["translateZ"];
            var rX = info["rotateX"];
            var rY = info["rotateY"];
            var rZ = info["rotateZ"];
            var s = info["scale"] * m_scaleFactor;
            var f = info["focal"];

            // Now perform matrix math...
            m_scaling     = ASMATRIX4.CreateScalingMatrix(s, s, s);
            m_translation = ASMATRIX4.CreateTranslationMatrix(tX, tY, tZ);
            m_perspective = ASMATRIX4.CreatePerspectiveMatrix(f);
            m_rotation    = ASMATRIX4.RotateByDegrees(rX, rY, rZ);
        }

        /// <summary>
        /// Transforms the mesh by the Perspecitve, Translation and Scaling Matrixes
        /// </summary>
        private void TransformMesh()
        {
            var transformationMatrix = m_translation*m_scaling*m_rotation*m_perspective;
            for (var i = 0; i < m_numFaces; i++)
            {
                m_meshData[i] = m_meshData[i].TransformFace(transformationMatrix);
            }
        }
    }
}
