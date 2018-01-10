var IsplaceChange = false;
        $(document).ready(function () {
            var input = document.getElementById('search');
            var autocomplete = new google.maps.places.Autocomplete(input, { componentRestrictions: {country: "pl"} });

            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                var place = autocomplete.getPlace();

                IsplaceChange = true;
            });

            $("#search").keydown(function () {
                IsplaceChange = false;
            });

            $("#btnsubmit").click(function () {

                if (IsplaceChange == false) {
                    $("#search").val('');
                    alert("Wybierz lokalizację z listy");
					return false;
                }

            });
        });