<!DOCTYPE html>
<html>
<head>
    <title>Music Mood Finder</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
</head>
<body>
<div class="container">
     <div class="col-md-8 col-md-offset-2">
    	<div class="panel panel-default">
	      	<div class="panel-heading">Select a mood and get a song</div>
	      	<div class="panel-body">
	            <div class="form-group">
	                <label for="title">Select Mood:</label>
	                <select id="mood" class="form-control" onchange="goToResult(this.value);">
                        <option>Kies hier</option>
	                    <option value="blij">Blij</option>
	                    <option value="triest">Droevig</option>
	                </select>
	            </div>
	      	</div>
      	</div>
    </div>
</div>

<script>
function goToResult(mood) {
    url = "/result/" + mood
  location.replace(url)
}
</script>
</body>
</html>