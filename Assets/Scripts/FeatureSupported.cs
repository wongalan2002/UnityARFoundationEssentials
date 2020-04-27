using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class FeatureSupported : MonoBehaviour
{
    [SerializeField]
    private Text features;

    [SerializeField]
    private ARFaceManager arFaceManager;

    [SerializeField]
    private ARHumanBodyManager arHumanBodyManager;

    [SerializeField]
    private AROcclusionManager aROcclusionManager;

    [SerializeField]
    private ARPointCloudManager arPointCloudManager;


    bool supportsEyeTracking = false;
    bool supportsFacePose = false;
    bool supportsFaceMeshVerticesAndIndices = false;
    bool supportsHumanBody2D = false;
    bool supportsHumanBody3D = false;
    bool supportsHumanDepthImage = false;
    bool supportsHumanStencilImage = false;
    bool supportsConfidence = false;
    bool supportsFeaturePoints = false;

    void Start()
    {
        // Face Support Checks
        try
        {
            supportsEyeTracking = arFaceManager.subsystem.SubsystemDescriptor.supportsEyeTracking;
            supportsFacePose = arFaceManager.subsystem.SubsystemDescriptor.supportsFacePose;
            supportsFaceMeshVerticesAndIndices = arFaceManager.subsystem.SubsystemDescriptor.supportsFaceMeshVerticesAndIndices;
        }
        catch
        {
            supportsEyeTracking = false;
            supportsFacePose = false;
            supportsFaceMeshVerticesAndIndices = false;
        }

        // Human Body Support Checks
        try
        {
            supportsHumanBody2D = arHumanBodyManager.subsystem.SubsystemDescriptor.supportsHumanBody2D;
            supportsHumanBody3D = arHumanBodyManager.subsystem.SubsystemDescriptor.supportsHumanBody3D;
        }
        catch
        {
            supportsHumanBody2D = false;
            supportsHumanBody3D = false;
        }

        try
        {
            supportsHumanDepthImage = aROcclusionManager.subsystem.SubsystemDescriptor.supportsHumanSegmentationDepthImage;
            supportsHumanStencilImage = aROcclusionManager.subsystem.SubsystemDescriptor.supportsHumanSegmentationStencilImage;
        }
        catch
        {
            supportsHumanDepthImage = false;
            supportsHumanStencilImage = false;
        }


        // Point Cloud Support Checks
        try
        {
            supportsConfidence = arPointCloudManager.subsystem.SubsystemDescriptor.supportsConfidence;
            supportsFeaturePoints = arPointCloudManager.subsystem.SubsystemDescriptor.supportsFeaturePoints;
        }
        catch
        {
            supportsConfidence = false;
            supportsFeaturePoints = false;
        }

        features.text = $"supportsEyeTracking : {supportsEyeTracking}\n" +
            $"supportsFacePose : {supportsFacePose}\n" +
            $"supportsFaceMeshVerticesAndIndices : {supportsFaceMeshVerticesAndIndices}\n" +
            $"supportsHumanBody2D : {supportsHumanBody2D}\n" +
            $"supportsHumanBody3D : {supportsHumanBody3D}\n" +
            $"supportsHumanDepthImage : {supportsHumanDepthImage}\n" +
            $"supportsHumanDepthImage : {supportsHumanStencilImage}\n" +
            $"supportsConfidence : {supportsConfidence}\n" +
            $"supportsFeaturePoints : {supportsFeaturePoints}";

        Debug.Log("features :" + features.text);
    }
}
