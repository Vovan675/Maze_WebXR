<!DOCTYPE html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Unity WebGL Player | %UNITY_WEB_NAME%</title>
    <link rel="shortcut icon" href="TemplateData/favicon.ico">
    <link rel="stylesheet" href="TemplateData/style.css">
    <script src="TemplateData/UnityProgress.js"></script>
    <script src="%UNITY_WEBGL_LOADER_URL%"></script>
    <script>
      var unityInstance = UnityLoader.instantiate("unityContainer", "%UNITY_WEBGL_BUILD_URL%", {onProgress: function(unityInstance, progress) { UnityProgress(unityInstance, progress); unityInstance.SendMessage("Hook", "SetName", <?php echo '"' . $_POST["name"] . '"'; ?>);}});
    </script>
  </head>
  <body>
    <div class="webgl-content">
      <div id="unityContainer" style="width: %UNITY_WIDTH%px; height: %UNITY_HEIGHT%px"></div>
      <div class="footer">
        <div class="webgl-logo"></div>
        <div class="fullscreen" onclick="unityInstance.SetFullscreen(1)"></div>
        <div class="title">%UNITY_WEB_NAME%</div>
      </div>
    </div>
  </body>
</html>
