﻿using System.Collections.Generic;
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

    

    public bool needEyeTracking = false;
    public bool needFacePose = false;
    public bool needFaceMeshVerticesAndIndices = false;
    public bool needHumanBody2D = false;
    public bool needHumanBody3D = false;
    public bool needHumanDepthImage = false;
    public bool needHumanStencilImage = false;
    public bool needConfidence = false;
    public bool needFeaturePoints = false;

    public List<bool> requiredList;

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
        if (needEyeTracking) requiredList.Add(needEyeTracking);
        if (needFacePose) requiredList.Add(needFacePose);
        if (needFaceMeshVerticesAndIndices) requiredList.Add(needFaceMeshVerticesAndIndices);
        if (needHumanBody2D) requiredList.Add(needHumanBody2D);
        if (needHumanBody3D) requiredList.Add(needHumanBody3D);
        if (needHumanDepthImage) requiredList.Add(needHumanDepthImage);
        if (needHumanStencilImage) requiredList.Add(needHumanStencilImage);
        if (needConfidence) requiredList.Add(needConfidence);
        if (needFeaturePoints) requiredList.Add(needFeaturePoints);

        //CheckFeatures();
        
        if (CheckFeatures() == requiredList.Count)
        {
            Debug.Log("Pass all");
        }
        else
        {
            Debug.Log("Totally required: " + requiredList.Count + " but only " + CheckFeatures() + " supported");

            features.text = $"supportsEyeTracking : {supportsEyeTracking}\n" +
            $"supportsFacePose : {supportsFacePose}\n" +
            $"supportsFaceMeshVerticesAndIndices : {supportsFaceMeshVerticesAndIndices}\n" +
            $"supportsHumanBody2D : {supportsHumanBody2D}\n" +
            $"supportsHumanBody3D : {supportsHumanBody3D}\n" +
            $"supportsHumanDepthImage : {supportsHumanDepthImage}\n" +
            $"supportsHumanDepthImage : {supportsHumanStencilImage}\n" +
            $"supportsConfidence : {supportsConfidence}\n" +
            $"supportsFeaturePoints : {supportsFeaturePoints}";
        }
        Debug.Log("features :" + features.text);
    }

    int CheckFeatures()
    {
        int counter = 0;
        if (needEyeTracking)
        {
            try
            {
                supportsEyeTracking = arFaceManager.subsystem.SubsystemDescriptor.supportsEyeTracking;
                if (supportsEyeTracking) counter++;
            }
            catch
            {
                supportsEyeTracking = false;
            }
        }

        if (needFacePose)
        {
            try
            {
                supportsFacePose = arFaceManager.subsystem.SubsystemDescriptor.supportsFacePose;
                if (supportsFacePose) counter++;
            }
            catch
            {
                supportsFacePose = false;
            }
        }

        if (needFaceMeshVerticesAndIndices)
        {
            try
            {
                supportsFaceMeshVerticesAndIndices = arFaceManager.subsystem.SubsystemDescriptor.supportsFaceMeshVerticesAndIndices;
                if (supportsFaceMeshVerticesAndIndices) counter++;
            }
            catch
            {
                supportsFaceMeshVerticesAndIndices = false;
            }
        }

        if (needHumanBody2D)
        {
            try
            {
                supportsHumanBody2D = arHumanBodyManager.subsystem.SubsystemDescriptor.supportsHumanBody2D;
                if (supportsHumanBody2D) counter++;
            }
            catch
            {
                supportsHumanBody2D = false;
            }
        }

        if (needHumanBody3D)
        {
            try
            {
                supportsHumanBody3D = arHumanBodyManager.subsystem.SubsystemDescriptor.supportsHumanBody3D;
                if (supportsHumanBody3D) counter++;
            }
            catch
            {
                supportsHumanBody3D = false;
            }
        }

        if (needHumanDepthImage)
        {
            try
            {
                supportsHumanDepthImage = aROcclusionManager.subsystem.SubsystemDescriptor.supportsHumanSegmentationDepthImage;
                if (supportsHumanDepthImage) counter++;
            }
            catch
            {
                supportsHumanDepthImage = false;
            }
        }

        if (needHumanStencilImage)
        {
            try
            {
                supportsHumanStencilImage = aROcclusionManager.subsystem.SubsystemDescriptor.supportsHumanSegmentationStencilImage;
                if (supportsHumanStencilImage) counter++;
            }
            catch
            {
                supportsHumanStencilImage = false;
            }
        }

        if (needConfidence)
        {
            try
            {
                supportsConfidence = arPointCloudManager.subsystem.SubsystemDescriptor.supportsConfidence;
                if (supportsConfidence) counter++;
            }
            catch
            {
                supportsConfidence = false;
            }
        }

        if (needFeaturePoints)
        {
            try
            {
                supportsFeaturePoints = arPointCloudManager.subsystem.SubsystemDescriptor.supportsFeaturePoints;
                if (supportsFeaturePoints) counter++;
            }
            catch
            {
                supportsFeaturePoints = false;
            }
        }
        return counter;
    }
}
