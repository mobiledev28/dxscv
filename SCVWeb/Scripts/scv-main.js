jQuery(document).ready(function ($) {

    var oTable;
    var $form_modal = $('.cd-user-modal'),
		$form_login = $form_modal.find('#cd-login'),
		$form_signup = $form_modal.find('#cd-signup'),
		$form_forgot_password = $form_modal.find('#cd-reset-password'),
		$form_modal_tab = $('.cd-switcher'),
		$tab_login = $form_modal_tab.children('li').eq(0).children('a'),
		$tab_signup = $form_modal_tab.children('li').eq(1).children('a'),
		$forgot_password_link = $form_login.find('.cd-form-bottom-message a'),
		$back_to_login_link = $form_forgot_password.find('.cd-form-bottom-message a'),
		$main_nav = $('.main-nav');

    $form_modal.addClass('is-visible');
    login_selected();

    //open modal
    $main_nav.on('click', function (event) {

        if ($(event.target).is($main_nav)) {
            // on mobile open the submenu
            $(this).children('ul').toggleClass('is-visible');
        } else {
            // on mobile close submenu
            $main_nav.children('ul').removeClass('is-visible');
            //show modal layer
            $form_modal.addClass('is-visible');
            //show the selected form
            ($(event.target).is('.cd-signup')) ? signup_selected() : login_selected();
        }

    });

    //close modal

    //close modal when clicking the esc keyboard button
    $(document).keyup(function (event) {
        if (event.which == '27') {
            $form_modal.removeClass('is-visible');
        }
    });

    //switch from a tab to another
    $form_modal_tab.on('click', function (event) {
        event.preventDefault();
        ($(event.target).is($tab_login)) ? login_selected() : signup_selected();
    });

    //hide or show password
    $('.hide-password').on('click', function () {
        var $this = $(this),
			$password_field = $this.prev('input');

        ('password' == $password_field.attr('type')) ? $password_field.attr('type', 'text') : $password_field.attr('type', 'password');
        ('Hide' == $this.text()) ? $this.text('Show') : $this.text('Hide');
        //focus and move cursor to the end of input field
        $password_field.putCursorAtEnd();
    });

    //show forgot-password form 
    $forgot_password_link.on('click', function (event) {
        event.preventDefault();
        forgot_password_selected();
    });

    //back to login from the forgot-password form
    $back_to_login_link.on('click', function (event) {
        event.preventDefault();
        login_selected();
    });

    function login_selected() {
        $form_login.addClass('is-selected');
        $form_signup.removeClass('is-selected');
        $form_forgot_password.removeClass('is-selected');
        $tab_login.addClass('selected');
        $tab_signup.removeClass('selected');
    }

    function signup_selected() {
        $form_login.removeClass('is-selected');
        $form_signup.addClass('is-selected');
        $form_forgot_password.removeClass('is-selected');
        $tab_login.removeClass('selected');
        $tab_signup.addClass('selected');
    }

    function forgot_password_selected() {
        $form_login.removeClass('is-selected');
        $form_signup.removeClass('is-selected');
        $form_forgot_password.addClass('is-selected');
    }

    //REMOVE THIS - it's just to show error messages 
    //$form_login.find('input[type="submit"]').on('click', function(event){
    //    event.preventDefault();
    //    var canSubmit = true;

    //    if ($form_login.find('input[type="email"]').val() == '') {
    //        canSubmit = false;
    //        $form_login.find('input[type="email"]').toggleClass('has-error').next('span').toggleClass('is-visible');
    //    } else {
    //        $form_login.find('input[type="email"]').toggleClass('has-error').next('span').removeClass('is-visible');
    //    }

    //    if ($form_login.find('input[type="contra"]').val() == '') {
    //        canSubmit = false;
    //        $form_login.find('input[type="contra"]').toggleClass('has-error').next('span').toggleClass('is-visible');
    //    } else {
    //        $form_login.find('input[type="contra"]').toggleClass('has-error').next('span').removeClass('is-visible');
    //    }

    //    if (canSubmit){
    //        $form_login.submit();
    //    }	
    //});
    //$form_signup.find('input[type="submit"]').on('click', function(event){
    //	event.preventDefault();
    //	$form_signup.find('input[type="email"]').toggleClass('has-error').next('span').toggleClass('is-visible');
    //});


    //IE9 placeholder fallback
    //credits http://www.hagenburger.net/BLOG/HTML5-Input-Placeholder-Fix-With-jQuery.html
    if (!Modernizr.input.placeholder) {
        $('[placeholder]').focus(function () {
            var input = $(this);
            if (input.val() == input.attr('placeholder')) {
                input.val('');
            }
        }).blur(function () {
            var input = $(this);
            if (input.val() == '' || input.val() == input.attr('placeholder')) {
                input.val(input.attr('placeholder'));
            }
        }).blur();
        $('[placeholder]').parents('form').submit(function () {
            $(this).find('[placeholder]').each(function () {
                var input = $(this);
                if (input.val() == input.attr('placeholder')) {
                    input.val('');
                }
            })
        });
    }

});


//credits http://css-tricks.com/snippets/jquery/move-cursor-to-end-of-textarea-or-input/
jQuery.fn.putCursorAtEnd = function () {
    return this.each(function () {
        // If this function exists...
        if (this.setSelectionRange) {
            // ... then use it (Doesn't work in IE)
            // Double the length because Opera is inconsistent about whether a carriage return is one character or two. Sigh.
            var len = $(this).val().length * 2;
            this.setSelectionRange(len, len);
        } else {
            // ... otherwise replace the contents with itself
            // (Doesn't work in Google Chrome)
            $(this).val($(this).val());
        }
    });
};


var ScriptDynamic = {
    GetMarkerDetails: function (custnum, status, fechainicial, fechafinal) {
        $.ajax({
            beforeSend: function () {
                $('.loading').show();
            },
            complete: function () {
                $('.loading').hide();
            },
            url: '/Map/GetMarkerDetails',
            type: 'GET',
            dataType: 'json',
            data: {
                custnum: custnum,
                status: status,
                fechainicial: fechainicial,
                fechafinal: fechafinal
            },
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                //ScriptDynamic.CreateDetailsSection(data);
                $('#modalDetails').modal('show');
            },
            error: function () {
                alert("error");
            }
        });
    },
    getDetails: function (locationid) {
        $.ajax({
            beforeSend: function () {
                $('.loading').show();
            },
            complete: function () {
                $('.loading').hide();
            },
            url: '/Map/GetMarkerDetails',
            type: 'GET',
            dataType: 'json',
            data: { locationid: locationid },
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                ScriptDynamic.CreateDetailsSection(data);
            },
            error: function () {
                alert("error");
            }
        });
    },
    CreateDetailsSection: function (data) {
        var div = document.createElement('div');
        var html = "<ul><li><span>" + data.data.Details + "</span></li>";
        html = html + "<li>" + data.data.FullName + "</li>";
        html = html + "<li>" + data.data.Phone + "</li>";
        html = html + "<li>" + data.data.Schedule + "</li>";
        html = html + "</ul>";

        div.innerHTML = html;

        $('#details').html('');
        document.getElementById('details').appendChild(div);
    },
    GuardaDatosCuenta: function (username, password, passwordconfirm) {
        //Almacena los datos de la cuenta nueva
        if (password != passwordconfirm) {
            alert("La confirmación de la contraseña no coincide. Por favor verifica esta información.");
            return;
        } else {
            $.ajax({
                beforeSend: function () {
                    $('.loading').show();
                },
                complete: function () {
                    $('.loading').hide();
                },
                url: '/Account/GuardaDatosCuenta',
                type: 'GET',
                dataType: 'json',
                data: {
                    username: username,
                    password: password
                },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    //$('.markers-container').empty();
                    if (data.success == "yes") {
                        
                    } else if (data.success == "no") {
                        alert(data.failure);
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
        
    },
    CreateMarkerDiv: function (data) {
        var div = document.createElement('div');
        var html = "<div class=\"divmarker\" data-latitude=\"" + data.Latitude + "\" data-longitude=\"" + data.Longitude + "\"" + "data-custnum=\"" + data.CustNum + "\"></div>";
        div.innerHTML = html;
        document.getElementById('markers').appendChild(div);
    },
    AddMarkers: function (data) {
        var markerCount = 0;
        /*
            Por Autorizar – Amarillo
            Autorizadas – Verde
            Servicio Rechazado – Rojo
            Cotización – Azul
                
        */

        switch (data.Status) {
            case "Por Asignar":
                image = "../Images/pin_location_orange.png";
                break;
            case "Asignada":
                image = "../Images/pin_location_green.png";
                break;
            case "Cotizacion":
                image = "../Images/pin_location_blue.png";
                break;
            case "Servicio Rechazado":
                image = "../Images/pin_location_red.png";
                break;
            default:
                image = "../Images/pin_location_purple.png";
                break;

        }

        var latlng = new google.maps.LatLng(data.Latitude, data.Longitude);
        var marker = new google.maps.Marker({
            position: latlng,
            title: data.Status + ' ' + data.OrderNum + ' latitude: ' + data.Latitude + ' longitude: ' + data.Longitude,
            draggable: true,
            icon: image,
            animation: google.maps.Animation.DROP,
            map: map
        });

        map.setCenter(marker.getPosition());

        //Gives each marker an Id for the on click
        markerCount++;

        markersOnMap.push(marker);

        google.maps.event.addListener(marker, 'dblclick', (function (marker, markerCount) {
            return function () {
                //ScriptDynamic.getDetails(locationid);
                //alert(data.CustNum + '****' + data.Status);
                $('#myModal').modal('hide');
                //ScriptDynamic.GetMarkerDetails(data.CustNum, data.Status);
                UpdateDataTable(data.Cliente, data.Status);
                $('#modalDetails').modal('show');

            }
        })(marker, markerCount));
    },
    SetMapOnAll: function (map) {
        for (var i = 0; i < markersOnMap.length; i++) {
            markersOnMap[i].setMap(map);
        }
    }
}
