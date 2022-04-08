<!DOCTYPE html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Unity WebGL Player | %UNITY_WEB_NAME%</title>
    <meta name="description" content="%UNITY_CUSTOM_DESCRIPTION%">
    <link rel="shortcut icon" href="TemplateData/favicon.ico">
    <link rel="stylesheet" href="TemplateData/style.css">
    <script src="TemplateData/UnityProgress.js"></script>
    <script src="%UNITY_WEBGL_LOADER_URL%"></script>
    <script>
      UnityLoader.compatibilityCheck = function (unityInstance, onsuccess, onerror) {
        if (!UnityLoader.SystemInfo.hasWebGL) {
          unityInstance.popup('Your browser does not support WebGL',
            [{text: 'OK', callback: onerror}]);
        } else {
          onsuccess();
        }
      }
      %UNITY_CUSTOM_WEBXR_POLYFILL_CONFIG%
      var unityInstance = UnityLoader.instantiate("unityContainer", "%UNITY_WEBGL_BUILD_URL%", {onProgress: function f(instance, progress) { UnityProgress(instance, progress); unityInstance.SendMessage("Menu", "SetName", "<?php echo $_POST["name"]; ?>");}});
    </script>
  </head>
  <body>
    <div class="webgl-content">
      <div id="unityContainer" style="width: %UNITY_WIDTH%px; height: %UNITY_HEIGHT%px"></div>
      <div class="footer">
        <div class="webgl-logo"></div>
        <button class="entervr" id="entervr" value="Enter VR" disabled>VR</button>
        <button class="enterar" id="enterar" value="Enter AR" disabled>AR</button>
        <div class="webxr-link">Using <a href="https://github.com/De-Panther/unity-webxr-export" target="_blank" title="WebXR Export">WebXR Export</a></div>
        <div class="title">%UNITY_WEB_NAME%</div>
      </div>
    </div>
    <script>
      let enterARButton = document.getElementById('enterar');
      let enterVRButton = document.getElementById('entervr');
      
      document.addEventListener('onARSupportedCheck', function (event) {
        enterARButton.disabled = !event.detail.supported;
      }, false);
      document.addEventListener('onVRSupportedCheck', function (event) {
        enterVRButton.disabled = !event.detail.supported;
      }, false);
      
      enterARButton.addEventListener('click', function (event) {
        unityInstance.Module.WebXR.toggleAR();
      }, false);
      enterVRButton.addEventListener('click', function (event) {
        unityInstance.Module.WebXR.toggleVR();
      }, false);
    </script>
  </body>
</html>
