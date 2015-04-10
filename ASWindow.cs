using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASLoader
{
    /// <summary>
    /// The ASWindow class is responsible for the GUI for this project
    /// </summary>
    public partial class ASWindow : Form
    {
        // Directory to the models folder, we only take a name from the select box to
        // process the model to load
        private const string    MODEL_DIR = "../../models/";
        private string m_currModel = MODEL_DIR + ASModels.CUBE + ".txt";
        private bool m_hasBeenDrawn = false;
        private ASRenderer      m_renderer;
        private ASMesh          m_model;
        private Dictionary<string, int> m_worldInfo;

        /// <summary>
        /// Construct the new Window
        /// </summary>
        public ASWindow()
        {
            InitializeComponent();

            // Init the world info dictionary and set its values
            m_worldInfo = new Dictionary<string, int>();
            SetWorldInfo();

            // Create a new model from file and then build the, by default we
            // will draw the cube to the screen
            m_model    = new ASMesh(m_currModel);
            m_renderer = new ASRenderer(m_model.GetMeshData(), this);

            // Create the model list and update the GUI labels for this mesh
            // and then set the world info dictionary
            InitModelList();
            UpdateLabels();
        }

        /// <summary>
        /// Sets all of the models in the list
        /// </summary>
        private void InitModelList()
        {
            // Set the models list
            selectModel.Items.Add("Teapot");
            selectModel.Items.Add("Tiger");
            selectModel.Items.Add("T-Rex");
            selectModel.Items.Add("Dolphin");
            selectModel.Items.Add("Cube");
        }

        /// <summary>
        /// Sets the world info dictionary with the current values of sliders
        /// from the UI
        /// </summary>
        private void SetWorldInfo()
        {
            m_worldInfo["focal"]      = focal.Value;
            m_worldInfo["scale"]      = scale.Value;
            m_worldInfo["translateX"] = translateX.Value;
            m_worldInfo["translateY"] = translateY.Value;
            m_worldInfo["translateZ"] = translateZ.Value;

            canvas.Refresh();
        }

        /// <summary>
        /// Update the info labels on the GUI for this mesh
        /// </summary>
        private void UpdateLabels()
        { 
            var data = m_model.GetMeshData();

            lblNormals.Text  = string.Format("# Faces: {0}", data["numFaces"]);
            lblVertices.Text = string.Format("# Vertices: {0}", data["numVertices"]);
        }

        /// <summary>
        /// Load the new model once this changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the name of the model
            switch (selectModel.SelectedItem.ToString())
            { 
                case "Teapot":
                    m_currModel = MODEL_DIR + ASModels.TEAPOT + ".txt";
                    break;
                case "Tiger":
                    m_currModel = MODEL_DIR + ASModels.TIGER + ".txt";
                    break;
                case "T-Rex":
                    m_currModel = MODEL_DIR + ASModels.T_REX + ".txt";
                    break;
                case "Dolphin":
                    m_currModel = MODEL_DIR + ASModels.DOLPHIN + ".txt";
                    break;
                case "Cube":
                    m_currModel = MODEL_DIR + ASModels.CUBE + ".txt";
                    break;
            }

            m_hasBeenDrawn = false;
            SetWorldInfo();
        }

        /// <summary>
        /// Calls the renderer to draw the mesh to the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Check if the mesh has already been drawn, there was a bug where
            // the canvas would keep firing draw events, wasn't showing in stack trace
            // so this is a temp fix...This bool is reset on a btnDraw click event
            if (m_hasBeenDrawn) return;

            // Set the model to draw
            m_model = new ASMesh(m_currModel);

            // Update the renderer and then reload the canvas
            m_renderer.SetWorldInfo(m_worldInfo);
            m_renderer.SetMeshData(m_model.GetMeshData());

            UpdateLabels();
            m_hasBeenDrawn = m_renderer.RenderMesh();
        }

        /// <summary>
        /// Public interface to get the canvas object
        /// </summary>
        /// <returns></returns>
        public Panel GetCanvas()
        {
            return canvas;
        }

        /************************************************************
         * 
         *  The below methods all handle calling a new draw event with
         *  SetWorldInfo(), this will re-render the model...
         * 
         ************************************************************/
        private void btnDraw_Click(object sender, EventArgs e)
        {
            m_hasBeenDrawn = false;
            SetWorldInfo();
        }
    }
}
