using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ASLoader.math;

namespace ASLoader
{
    /// <summary>
    /// The ASRenderer class is responsible for drawing the model to the 
    /// canvas by using C#'s graphics component
    /// </summary>
    class ASRenderer
    {
        /// <summary>
        /// Graphics    - The graphics context we will be drawing too
        /// Pen         - Handle to the pen to draw lines
        /// ASWindow    - Handle to the window we wish to draw too
        /// ASMATRIX3[] - All data on the mesh
        /// ASVECTOR3[] - All of the vertices on the mesh
        /// ASMATRIX3[] - All of the normals from the mesh
        /// string      - represents the last error which had occured
        /// int         - The number of vertices
        /// int         - The number of indices
        /// </summary>
        private Graphics    m_graphicsContext;
        private Pen         m_pen;
        private ASWindow    m_window;
        private Panel       m_canvas;
        private ASFace[]    m_meshData;
        private ASVECTOR3[] m_vertices;
        private ASVECTOR3[] m_vNormals;
        public string       m_lastErr;
        private int         m_numVertices;
        private int         m_numFaces;
        private Dictionary<string, int> m_worldInfo;

        private ASMATRIX4   m_perspective;
        private ASMATRIX4   m_translation;
        private ASMATRIX4   m_scaling;

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
            m_vertices      = modelData["vertices"] as ASVECTOR3[];
            m_vNormals      = modelData["normals"] as ASVECTOR3[];
            m_numFaces      = Convert.ToInt32(modelData["numFaces"]);
            m_numVertices   = Convert.ToInt32(modelData["numVertices"]);
        }

        /// <summary>
        /// Sets the world info dictionary
        /// </summary>
        public void SetWorldInfo(Dictionary<string, int> info)
        {
            m_worldInfo = info;
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

                // Draw the mesh
                for (var i = 0; i < m_numFaces; i++)
                {
                    var face = m_meshData[i];

                    // Draw the face
                    for (var j = 0; j < 2; j++)
                    {
                        m_graphicsContext.DrawLine(m_pen,
                                                     (int)face.GetPointAtIndex(j).Points[0],
                                                     (int)face.GetPointAtIndex(j).Points[1],
                                                     (int)face.GetPointAtIndex(j + 1).Points[0],
                                                     (int)face.GetPointAtIndex(j + 1).Points[1]
                                                  );
                    }
                    // Draw from first point back to last line
                    m_graphicsContext.DrawLine(m_pen,
                                                 (int)face.GetPointAtIndex(2).Points[0],
                                                 (int)face.GetPointAtIndex(2).Points[1],
                                                 (int)face.GetPointAtIndex(0).Points[0],
                                                 (int)face.GetPointAtIndex(0).Points[1]
                                               );
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
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
            var s = info["scale"];
            var f = info["focal"];

            // Now perform matrix math...
            m_perspective.CreatePerspectiveMatrix(f);
            m_translation.CreateTranslationMatrix(tX, tY, tZ);
            m_scaling.CreateScalingMatrix(s, s, s);
        }

        /// <summary>
        /// Transforms the mesh by the Perspecitve, Translation and Scaling Matrixes
        /// </summary>
        private void TransformMesh()
        {
            for (var i = 0; i < m_numFaces; i++)
            {
                m_meshData[i] = m_meshData[i].TransformFace(m_scaling);
                m_meshData[i] = m_meshData[i].TransformFace(m_translation);
                m_meshData[i] = m_meshData[i].TransformFace(m_perspective);
            }
        }
    }
}
