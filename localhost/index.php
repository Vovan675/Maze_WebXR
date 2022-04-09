<!DOCTYPE html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <script src="script.js"></script>
    <link href="table.css" rel="stylesheet" type="text/css">
  </head>
  <body>
    <?php
      include("setName.php");
    ?>
    <form action="game/index.php" method="POST">
      <label for="name">Name:</label>
      <input name="name" type="text">
      <input type="submit">
    </form>
    <br>
    <?php
      include("showTable.php");
    ?>
  </body>
</html>
    