(function () {

    angular
        .module('pastelaria')
        .constant('ApiSettingsConstant', ApiSettingsConstants());

    function ApiSettingsConstants() {
        return {
            apiServiceBaseUri: "http://localhost:64540/api"
        };
    }

})();