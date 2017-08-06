System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var NotificationType;
    return {
        setters: [],
        execute: function () {
            (function (NotificationType) {
                NotificationType[NotificationType["Info"] = 0] = "Info";
                NotificationType[NotificationType["Warning"] = 1] = "Warning";
                NotificationType[NotificationType["Error"] = 2] = "Error";
            })(NotificationType || (NotificationType = {}));
            exports_1("NotificationType", NotificationType);
        }
    };
});
//# sourceMappingURL=Notification.js.map