$(document).ready(function () {
	$(".calculator").each(function () {
		this.visor = $(".visor", this)[0];
		this.buttons = $("button", this).toArray();
		var list = this.buttons.map(x => {
			var key = x.getAttribute("key");
			var value = x.getAttribute("value");
			var cmd = x.getAttribute("cmd");
			var k = key || value;  //obter a tecla ou o valor
			return { [k]: x };
		});
		var mapa = Object.assign({}, ...list);
		this.buttonFromKey = (key) => mapa[key];

		var v = this.visor;

		//funções de tratamento da operação
		this.concat = (k) => {
			if (v.value == "Infinity") {
				this.clear();
			}
			v.value += k;
		};
		this.delete = () => v.value = v.value.substr(0, v.value.length - 1);
		this.clear = () => v.value = "";
		this.calculate = () => {
			var value = v.value.replace("+", "%20");
			var post = `exp=${value}`;
			var url = "/api/Expression/Calculate";
			jQuery.post(url, post, function (result) {
				if (result != null)
					v.value = result.toString().replace(/[.]/g, ",");
			});
		};
	});
	$(".calculator button").click(function () {
		var calculator = $(this).parents(".calculator")[0];
		var cmd = this.getAttribute("cmd");
		var isCommand = cmd || false;
		if (isCommand) {
			eval(`calculator.${cmd}()`);
		} else {
			calculator.concat(this.getAttribute("value"));
		}
	});

	$(document).keydown(function (e) {
		var button = ativeCalculator.buttonFromKey(e.key);
		$(button).trigger("click");
	});


	window.ativeCalculator = $(".calculator")[0];  //mas poderiam ser outras calculadoras
});
