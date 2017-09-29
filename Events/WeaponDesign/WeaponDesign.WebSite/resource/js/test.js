$(function () {
    Page.initialize(), Input.initialize(), App.initialize(), Tickets.initialize(), Flash.initialize(), Locale.initialize(), CharSelect.initialize(), Core.initialize()
});
var Core = {
    baseUrl: "/",
    supportUrl: "/support/",
    browser: null,
    deferredLoadQueue: [],
    locale: "en-us",
    shortDateFormat: "MM/dd/Y",
    dateTimeFormat: "dd/MM/yyyy HH:mm",
    project: "",
    staticUrl: "/",
    sharedStaticUrl: "/local-common/",
    host: "",
    initialize: function () {
        Core.processLoadQueue(), Core.ui(), Core.host = location.protocol + "//" + (location.host || location.hostname)
    },
    alpha: function (a) {
        return a.replace(/[^a-zA-Z]/gi, "")
    },
    appendFrame: function (a, b, c, d, e) {
        "undefined" != typeof a && ("undefined" == typeof b && (b = 1), "undefined" == typeof c && (c = 1), "undefined" == typeof d && (d = $("body")), d.append(Core.isIE() ? '<iframe src="' + a + '" width="' + b + '" height="' + c + '" scrolling="no" frameborder="0" allowTransparency="true"' + ("undefined" != typeof e ? ' id="' + e + '"' : "") + "></iframe>" : '<object type="text/html" data="' + a + '" width="' + b + '" height="' + c + '"' + ("undefined" != typeof e ? ' id="' + e + '"' : "") + "></object>"))
    },
    fixTableHeaders: function (a, b) {
        $(a).each(function () {
            b = b || 18;
            var a = $(this), c = b;
            a.find(".sort-link").each(function () {
                var a = $(this).height();
                a > c && (c = a)
            }), c > b && a.find(".sort-link, .sort-tab").css("height", c)
        })
    },
    formatLocale: function (a, b) {
        switch (b = b || "-", a = a || 1) {
            case 1:
            default:
                return Core.locale.replace("-", b);
            case 2:
                var c = Core.locale.split("-");
                return c[0] + b + c[1].toUpperCase();
            case 3:
                return Core.locale.toUpperCase().replace("-", b)
        }
    },
    formatDatetime: function (a, b) {
        var c;
        if (b) {
            if (c = new Date(b), isNaN(c.getTime()) && (b = b.substring(0, 10) + " " + b.substring(11, 16) + ":00 GMT" + b.substring(16, 19) + b.substring(20, 22), c = new Date(b)), isNaN(c.getTime()) && (b = b.substring(0, 4) + "/" + b.substring(5, 7) + "/" + b.substring(8, 29), c = new Date(b)), isNaN(c.getTime()) && (b = b.substring(5, 10) + " " + b.substring(11, 16) + " GMT" + b.substring(23, 28) + " " + b.substring(0, 4), c = new Date(b)), isNaN(c.getTime()))return !1
        } else c = new Date;
        a || (a = "yyyy-MM-ddThh:mmZ");
        var d = c.getHours(), e = "AM";
        d > 12 ? (d -= 12, e = "PM") : 12 === d ? e = "PM" : 0 === d && (d = 12);
        var f = parseInt(c.getTimezoneOffset() / 60 * -1, 10);
        return f = 0 > f ? "-" + Core.zeroFill(Math.abs(f), 2) + ":00" : "+" + Core.zeroFill(Math.abs(f), 2) + ":00", a = a.replace("yyyy", c.getFullYear()), a = a.replace("MM", Core.zeroFill(c.getMonth() + 1, 2)), a = a.replace("dd", Core.zeroFill(c.getDate(), 2)), a = a.replace("HH", Core.zeroFill(c.getHours(), 2)), a = a.replace("hh", Core.zeroFill(d, 2)), a = a.replace("mm", Core.zeroFill(c.getMinutes(), 2)), a = a.replace("a", e), a = a.replace("Z", f)
    },
    getBrowser: function () {
        if (Core.browser)return Core.browser;
        var a = $.support;
        return Core.browser = a.hrefNormalized || a.tbody || a.style || a.opacity ? a.hrefNormalized && a.tbody && a.style && !a.opacity ? "ie8" : UserAgent.browser + UserAgent.version : "undefined" != typeof document.body.style.maxHeight || window.XMLHttpRequest ? "ie7" : "ie6", Core.browser
    },
    getHash: function () {
        var a = location.hash || "";
        return a.substr(1, a.length)
    },
    getLanguage: function () {
        return Core.locale.split("-")[0]
    },
    getRegion: function () {
        return Core.locale.split("-")[1]
    },
    goTo: function (a, b) {
        window.location.href = (b ? Core.baseUrl : "") + a, window.event && (window.event.returnValue = !1)
    },
    include: function (a, b, c) {
        $.ajax({url: a, dataType: "script", success: b, cache: c !== !1})
    },
    isCallback: function (a) {
        return a && "function" == typeof a
    },
    isIE: function (a) {
        var b = Core.getBrowser();
        return a ? "ie" + a == b : "ie6" == b || "ie7" == b || "ie8" == b || "ie9" == b
    },
    load: function (a, b, c) {
        b = b !== !1, Page.loaded || !b ? Core.loadDeferred(a, c) : Core.deferredLoadQueue.push(a)
    },
    loadDeferred: function (a, b) {
        var c = a.indexOf("?"), d = a.lastIndexOf(".") + 1, e = a.substring(d, -1 == c ? a.length : c);
        switch (e) {
            case"js":
                Core.loadDeferredScript(a, b);
                break;
            case"css":
                Core.loadDeferredStyle(a)
        }
    },
    loadDeferredScript: function (a, b) {
        $.ajax({url: a, cache: !0, global: !1, dataType: "script", success: b})
    },
    loadDeferredStyle: function (a, b) {
        $("head").append('<link rel="stylesheet" href="' + a + '" type="text/css" media="' + (b || "all") + '" />')
    },
    msg: function (a) {
        for (var b = 1, c = arguments.length; c > b; ++b)a = a.replace("{" + (b - 1) + "}", arguments[b]);
        return a
    },
    msgAll: function (a) {
        for (var b = 1, c = arguments.length; c > b; ++b)a = a.replace(new RegExp("\\{" + (b - 1) + "\\}", "g"), arguments[b]);
        return a
    },
    numeric: function (a) {
        return a = a.replace(/[^0-9]/gi, ""), (!a || isNaN(a)) && (a = 0), a
    },
    open: function (a) {
        return a.href && window.open(a.href), !1
    },
    preventDefault: function (a) {
        a.preventDefault()
    },
    processLoadQueue: function () {
        if (Core.deferredLoadQueue.length > 0)for (var a, b = 0; a = Core.deferredLoadQueue[b]; b++)Core.load(a)
    },
    randomNumber: function (a) {
        return Math.floor(Math.random() * a)
    },
    scrollTo: function (a, b, c) {
        if (a = $(a), 1 == a.length) {
            var d = $(window), e = d.scrollTop(), f = e + d.height(), g = a.offset().top;
            g -= 15, g >= e && f >= g || $($.browser.webkit ? "body" : "html").animate({scrollTop: g}, b || 350, c || null)
        }
    },
    scrollToVisible: function (a, b, c) {
        if (a = $(a), 1 == a.length) {
            var d = $(window), e = d.scrollTop(), f = e + d.height(), g = a.offset().top, h = g + a.height();
            g -= 15, h += 15, g >= e && f >= h || $($.browser.webkit ? "body" : "html").animate({scrollTop: e > g ? g : h - d.height()}, b || 350, c || null)
        }
    },
    stopPropagation: function (a) {
        a.stopPropagation()
    },
    trimChar: function (a, b) {
        return a.substr(0, 1) === b && (a = a.substr(1, a.length - 1)), a.substr(a.length - 1, a.length) === b && (a = a.substr(0, a.length - 1)), a
    },
    trimRight: function (a, b) {
        return b = b ? (b + "").replace(/([\[\]\(\)\.\?\/\*\{\}\+\$\^\:])/g, "\\$1") : " \\s ", (a + "").replace(new RegExp("[" + b + "]+$", "g"), "")
    },
    ui: function (a) {
        a = a || document, Core.isIE(6) && $(a).find("button.ui-button").hover(function () {
            this.hasAttribute("disabled") && -1 != this.className.indexOf("disabled") || $(this).addClass("hover")
        }, function () {
            $(this).removeClass("hover")
        }), "bam" != Core.project && $(a).find("button.ui-button").click(function (a) {
            var b = $(this), c = b.attr("data-text");
            return "undefined" == typeof c && (c = ""), "button" == this.tagName.toLowerCase() && "" != c && "submit" == b.attr("type") && (a.preventDefault(), a.stopPropagation(), b.find("span span").html(c), b.removeClass("hover").addClass("processing").attr("disabled", "disabled"), b.parents("form").submit()), !0
        })
    },
    zeroFill: function (a, b, c) {
        "undefined" == typeof c && (c = !1);
        var d = parseFloat(a), e = !1, f = b - d.toString().length, g = f - 1;
        if (0 > d && (d = Math.abs(d), e = !0, f++, g = f - 1), b > 0 && (d.toString().indexOf(".") > 0 && (c || (f += d.toString().split(".")[1].length), f++, g = f - 1), g >= 0))do d = "0" + d; while (g--);
        return e ? "-" + d : d
    },
    showUntilClosed: function (a, b, c) {
        c = c || {};
        var d = $(a), e = "bnet.closed." + b;
        if (!d.length || !Cookie.isSupported() || Cookie.read(e))return !1;
        var f = new Date;
        if (c.startDate) {
            var g = new Date(c.startDate);
            if (g - f > 0)return !1
        }
        if (c.endDate) {
            var h = new Date(c.endDate);
            if (0 > h - f)return !1
        }
        c.fadeIn ? d.fadeIn(c.fadeIn, c.onShow) : (d.show(), c.onShow && c.onShow());
        var i = $.extend({path: Core.baseUrl, expires: 8760}, c.cookieParams || {});
        return d.delegate("a", "click", function () {
            var a = $(this), b = a.data("label"), f = "close" == this.rel;
            f && (d.hide(), c.onHide && c.onHide()), (f || !c.closeButtonOnly) && Cookie.create(e, 1, i), b && BnetAds.trackImpression(c.trackingCategory || "Tracking", c.trackingAction || "Click", b)
        }), !0
    }
}, App = {
    initialize: function () {
        var a = $('a[rel="javascript"]');
        a.length && a.removeAttr("onclick").removeAttr("onmouseover").removeAttr("title").css("cursor", "pointer");
        var b = $("#support-link"), c = $("#explore-link"), d = $("#breaking-link");
        b.length > 0 && b.unbind().click(function () {
            return Tickets.loadStatus(), Toggle.open(this, "active", "#support-menu"), !1
        }), c.length > 0 && (c.unbind().click(function () {
            return Toggle.open(this, "active", "#explore-menu"), !1
        }), $("#explore-menu").delegate("a", "click", function () {
            var a = $(this), b = a.data("label");
            b || (b = "Other"), BnetAds.trackImpression("Battle.net Explore Menu", "Link Click", b)
        })), d.length > 0 && d.unbind().click(function () {
            return App.breakingNews(), !1
        })
    }, closeWarning: function (a, b) {
        $(a).hide(), b && App.saveCookie(b)
    }, breakingNews: function (a) {
        var b = $("#breaking-news"), c = $("#announcement-warning");
        c.is(":visible") ? (c.hide(), b.removeClass("opened")) : (c.show(), b.addClass("opened")), a && Cookie.create("serviceBar.breakingNews", a)
    }, saveCookie: function (a) {
        Cookie.create("serviceBar." + a, 1, {expires: 8760, path: "/"})
    }, resetCookie: function (a) {
        Cookie.create("serviceBar." + a, 0, {expires: 8760, path: "/"})
    }, serviceBar: function () {
        var a = Cookie.read("serviceBar.browserWarning"), b = Cookie.read("serviceBar.localeWarning");
        1 == a && $("#browser-warning").hide(), 1 == b && $("#i18n-warning").hide()
    }, totalModules: 0, totalLoaded: 0, modules: [], forceLoad: !0, sidebar: function (a) {
        if (App.totalModules = a.length, a.length)for (var b = 0; b <= a.length - 1; ++b)App.loadModule(a[b], b);
        window.setTimeout(function () {
            App.forceLoad && App.showSidebar()
        }, 5e3)
    }, showSidebar: function () {
        App.forceLoad = !1;
        for (var a = $("#sidebar").find(".sidebar-bot"), b = 0; b < App.totalModules; b++)App.modules[b] && App.modules[b].appendTo(a);
        $("#sidebar-loading").fadeOut("normal", function () {
            a.find(".sidebar-module").fadeIn(), $(this).remove()
        })
    }, loadModule: function (a, b) {
        var c = $("#sidebar").find(".sidebar-bot");
        $.ajax({
            url: Core.baseUrl + "/sidebar/" + a.type + (a.query || ""),
            type: "GET",
            dataType: "html",
            cache: !0,
            global: !1,
            success: function (a) {
                if (App.totalLoaded++, "" != $.trim(a)) {
                    var d = $(a);
                    d.find("a").each(function () {
                        var a = location.protocol + "//" + location.host + location.pathname;
                        $(this).attr("href", $(this).attr("href").replace(a, "")), 0 != $.trim($(this).attr("href")).indexOf("/") && $(this).attr("href", Core.baseUrl + "/" + $(this).attr("href"))
                    }), App.forceLoad ? (d.hide(), App.modules[b] = d) : d.appendTo(c)
                }
            },
            error: function () {
                App.totalLoaded++
            },
            complete: function () {
                App.totalLoaded >= App.totalModules && window.setTimeout(App.showSidebar, 100)
            }
        })
    }
}, Cookie = {
    cache: {}, create: function (a, b, c) {
        if (c = $.extend({}, c), c.expires = c.expires || 1, "number" == typeof c.expires) {
            var d = c.expires;
            c.expires = new Date, c.expires.setTime(c.expires.getTime() + 36e5 * d)
        }
        var e = [encodeURIComponent(a) + "=", c.escape ? encodeURIComponent(b) : b, c.expires ? "; expires=" + c.expires.toUTCString() : "", c.path ? "; path=" + c.path : "", c.domain ? "; domain=" + c.domain : "", c.secure ? "; secure" : ""];
        document.cookie = e.join(""), Cookie.cache && (c.expires.getTime() < (new Date).getTime() ? delete Cookie.cache[a] : Cookie.cache[a] = b)
    }, read: function (a) {
        if (Cookie.cache[a])return Cookie.cache[a];
        var b = {}, c = document.cookie.split(";");
        if (c.length > 0)for (var d = 0; d < c.length; d++) {
            var e = c[d].split("=");
            e.length >= 2 && (b[$.trim(e[0])] = e[1])
        }
        return Cookie.cache = b, b[a] || null
    }, erase: function (a, b) {
        b ? b.expires || (b.expires = -1) : b = {expires: -1}, Cookie.create(a, 0, b)
    }, isSupported: function () {
        return -1 != document.cookie.indexOf("=")
    }
}, Input = {
    initialize: function () {
        Input.bind("#search-field")
    }, bind: function (a) {
        Input.reset(a);
        var b = $(a);
        b.focus(Input.activate).blur(Input.reset), b.parentsUntil("form").parent().submit(function () {
            return Input.submit(b)
        })
    }, activate: function (a) {
        var b = $("string" == typeof a ? a : this);
        b.length && (b.val() == b.attr("alt") && b.val(""), b.addClass("active"))
    }, reset: function (a) {
        var b = $("string" == typeof a ? a : this);
        b.length && ("" == b.val() ? b.removeClass("active").val(b.attr("alt")) : b.val() != b.attr("alt") && b.addClass("active"))
    }, submit: function (a) {
        return a = $(a || this), a.val() == a.attr("alt") && a.val(""), !0
    }
}, Page = {
    object: null,
    loaded: !1,
    dimensions: {width: 0, height: 0},
    scroll: {top: 0, width: 0},
    initialize: function () {
        Page.loaded || (Page.object || (Page.object = $(window)), Page.object.resize(Page.getDimensions).scroll(Page.getScrollValues), Page.getScrollValues(), Page.getDimensions(), Page.loaded = !0)
    },
    getScrollValues: function () {
        Page.scroll.top = Page.object.scrollTop(), Page.scroll.left = Page.object.scrollLeft()
    },
    getDimensions: function () {
        Page.dimensions.width = Page.object.width(), Page.dimensions.height = Page.object.height()
    }
}, Tickets = {
    tag: null, summary: null, fragment: null, ul: null, doc: null, total: 3, initialize: function () {
        Tickets.doc = document;
        var a = Tickets.doc;
        Tickets.tag = a.getElementById("support-ticket-count"), Tickets.summary = a.getElementById("ticket-summary"), Tickets.fragment = a.createDocumentFragment(), Tickets.ul = a.createElement("ul"), Tickets.loadStatus()
    }, updateSummary: function (a) {
        var b = Tickets.doc;
        if (Tickets.fragment = b.createDocumentFragment(), Tickets.ul = b.createElement("ul"), Tickets.summary.innerHTML = "", Tickets.fragment.appendChild(Tickets.ul), !(a.length < 1)) {
            for (var c, d = 0; c = a[d]; d++)Tickets.createListItem(c, d);
            Tickets.summary.appendChild(Tickets.fragment)
        }
    }, createListItem: function (a, b) {
        if ("object" == typeof a) {
            var c = Tickets.doc, d = Core.isIE(6) || Core.isIE(7) ? "className" : "class", e = Msg.support, f = {
                created: e.ticketNew,
                status: e.ticketStatus,
                viewAll: e.ticketAll,
                OPEN: e.ticketOpen,
                ANSWERED: e.ticketAnswered,
                RESOLVED: e.ticketResolved,
                CANCELED: e.ticketCanceled,
                ARCHIVED: e.ticketArchived,
                INFO: e.ticketInfo
            }, g = "", h = "", i = "", j = null, k = null, l = null, m = null, n = null, o = null, p = -1;
            g = "OPEN" === a.status ? f.created.replace("{0}", Core.buildRegion.toUpperCase() + a.caseId) : f.status.replace("{0}", Core.buildRegion.toUpperCase() + a.caseId), o = c.createElement("span"), o.setAttribute(d, "ticket-datetime"), o.appendChild(c.createTextNode(Tickets.localizeDatetime(a.lastUpdate))), l = c.createElement("a"), l.href = Core.secureSupportUrl + "ticket/thread/" + a.caseId, j = c.createElement("span"), j.setAttribute(d, "icon-ticket-status"), l.appendChild(j), p = g.indexOf("{1}"), p > 0 ? (h = g.substring(0, p), i = g.substr(p + 3, g.length), m = c.createElement("span"), m.setAttribute(d, "ticket-" + a.status.toLowerCase()), m.appendChild(c.createTextNode(f[a.status])), l.appendChild(c.createTextNode(h)), l.appendChild(m), l.appendChild(c.createTextNode(i))) : l.appendChild(c.createTextNode(g)), n = c.createElement("br"), l.appendChild(n), l.appendChild(o), k = c.createElement("li"), 0 === b && k.setAttribute(d, "first-ticket"), k.appendChild(l), Tickets.ul.appendChild(k), b === this.total && (k = c.createElement("li"), k.setAttribute(d, "view-all-tickets"), l = c.createElement("a"), l.href = Core.secureSupportUrl + "ticket/status", l.appendChild(c.createTextNode(f.viewAll)), k.appendChild(l), Tickets.ul.appendChild(k))
        }
    }, updateTotal: function (a) {
        a = "number" == typeof a ? a : 0;
        var b = Core.isIE(6) || Core.isIE(7) ? "className" : "class";
        a > 0 ? (Tickets.tag.setAttribute(b, "open-support-tickets"), Tickets.tag.innerHTML = a) : (Tickets.tag.setAttribute(b, "no-support-tickets"), Tickets.tag.innerHTML = "")
    }, localizeDatetime: function (a) {
        var b = Core.dateTimeFormat, c = Core.locale, d = null;
        return (d = Core.formatDatetime(b, a)) ? (("en-us" === c || "es-mx" === c || "zh-cn" === c || "zh-tw" === c) && (d = d.replace("/0", "/"), "0" === d.substr(0, 1) && (d = d.substr(1))), ("en-us" === c || "es-mx" === c) && (d = d.replace(" 0", " ")), d) : ""
    }, loadStatus: function () {
        null !== Tickets.summary && $.ajax({
            timeout: 3e3,
            url: Core.secureSupportUrl + "update/json",
            ifModified: !0,
            global: !1,
            dataType: "jsonp",
            jsonpCallback: "getStatus",
            data: {supportToken: supportToken},
            success: function (a) {
                Tickets.updateTotal(a.total), Tickets.updateSummary(a.details, a.total)
            }
        })
    }
}, Toggle = {
    cache: {}, callback: null, timeout: 800, keepOpen: !1, open: function (a, b, c, d) {
        d && (Toggle.timeout = d), Toggle.keepOpen = !0;
        var e = Toggle.key(c);
        for (var f in Toggle.cache)f !== e && Toggle.close(Toggle.cache[f].trigger, Toggle.cache[f].activeClass, Toggle.cache[f].target, 0, !0);
        Toggle.cache[e] || ($(a).mouseleave(function () {
            Toggle.keepOpen = !1, Toggle.close(a, b, c, Toggle.timeout)
        }).mouseenter(function () {
            Toggle.keepOpen = !0, window.clearTimeout(Toggle.cache[e].timer)
        }), $(c).mouseleave(function () {
            Toggle.keepOpen = !1, Toggle.close(a, b, c, Toggle.timeout)
        }).mouseenter(function () {
            Toggle.keepOpen = !0, window.clearTimeout(Toggle.cache[e].timer)
        }), Toggle.cache[e] = {
            trigger: a,
            target: c,
            activeClass: b,
            key: e,
            timer: null
        }), $(a).toggleClass(b), $(c).toggle(), window.clearTimeout(Toggle.cache[e].timer)
    }, close: function (a, b, c, d, e) {
        e = "boolean" == typeof e ? e : !1;
        var f = Toggle.key(c);
        window.clearTimeout(Toggle.cache[f].timer), Toggle.cache[f].timer = setTimeout(function () {
            (!Toggle.keepOpen || e) && ($(c).hide(), $(a).removeClass(b), Toggle.triggerCallback())
        }, d)
    }, key: function (a) {
        return "string" == typeof a ? a : "#" + $(a).attr("id")
    }, triggerCallback: function () {
        Core.isCallback(Toggle.callback) && Toggle.callback()
    }
}, Blackout = {
    initialized: !1, element: null, initialize: function () {
        Blackout.element = $("<div/>", {id: "blackout"}), Blackout.element.click(Core.stopPropagation), $("body").append(Blackout.element), Blackout.initialized = !0
    }, show: function (a, b) {
        Blackout.initialized || Blackout.initialize(), Blackout.element.css("width", Page.dimensions.width).css("height", $(document).height()), Blackout.element.show(), Core.isCallback(a) && a(), Core.isCallback(b) && Blackout.element.click(b)
    }, hide: function (a) {
        Blackout.initialized && (Blackout.element.hide(), Core.isCallback(a) && a(), Blackout.element.unbind("click"))
    }
}, CharSelect = {
    initialize: function () {
        $(document).undelegate("a.context-link", "click", CharSelect.toggle), $(document).delegate("a.context-link", "click", CharSelect.toggle), $("div.scrollbar-wrapper").css("overflow", "hidden"), $("input.character-filter").blur(function () {
            Toggle.keepOpen = !1
        }).keyup(CharSelect.filter), Input.bind(".character-filter")
    }, pin: function (a, b) {
        Tooltip.hide(), $("div.character-list").html("").addClass("loading-chars");
        var c = Core.baseUrl + "/pref/character";
        $.ajax({
            type: "POST", url: c, data: {index: a, xstoken: Cookie.read("xstoken")}, global: !1, success: function () {
                var a = c;
                return Core.isIE() ? void location.reload(!0) : -1 != location.pathname.indexOf("/character/") ? void(-1 != location.pathname.indexOf("/vault/") ? location.reload(!0) : CharSelect.redirectTo(b.href)) : (location.pathname.indexOf("/account-status") >= 0 ? a = Core.baseUrl + "/account-status" : location.pathname == Core.baseUrl + "/" && (a = Core.baseUrl + "/"), void CharSelect.pageUpdate())
            }
        })
    }, textareaContent: "", replace: function (a) {
        var b = $("string" == typeof a ? a : a.documentElement);
        $(".ajax-update").each(function () {
            var a, c = $(this);
            c.attr("id") ? a = "#" + c.attr("id") : (a = c.attr("class").replace("ajax-update", "").trim(), a = "." + a.split(" ")[0]), c.replaceWith(b.find(a + ".ajax-update").clone())
        }), CharSelect.initialize(), CharSelect.afterPageUpdate()
    }, pageUpdate: function (a, b) {
        a = a || location.href;
        var c = Date.parse(new Date);
        return Core.isIE() && a == Core.baseUrl + "/" ? void(location.href = location.pathname + "?reload=" + c) : (a = a + (a.indexOf("?") > -1 ? "&" : "?") + "cachekill=" + c, void $.ajax({
            url: a,
            global: !1,
            error: function (c) {
                b ? location.href = b : 404 == c.status && null == a ? CharSelect.pageUpdate(Core.baseUrl + "/", b) : location.reload(!0)
            },
            success: function (a) {
                CharSelect.replace(a)
            }
        }))
    }, afterPageUpdate: function () {
        var a;
        if (-1 != location.href.indexOf("/character/"))a = $("#user-plate a.character-name").attr("href"); else if (-1 != location.href.indexOf("/guild/") && (a = $("#user-plate a.guild-name").attr("href"), !a))return void(location.href = $("#user-plate a.character-name").attr("href"));
        a && CharSelect.redirectTo(a)
    }, redirectTo: function (a) {
        if (-1 != a.indexOf("/vault/"))return void location.reload();
        var b = "";
        location.href.match(/\/(character|guild)\/.+?\/.+?\/(.+)$/) && (b = RegExp.$2, $.each(["pet", "profession"], function () {
            return -1 != b.indexOf(this) ? void(b = "") : void 0
        })), location.href = a + b
    }, toggle: function (a) {
        return a.preventDefault(), a.stopImmediatePropagation(), Toggle.open(a.currentTarget, "context-open", $(a.currentTarget).siblings(".ui-context")), !1
    }, close: function (a) {
        return $(a).parents(".ui-context").hide().siblings(".context-link").removeClass("context-open"), !1
    }, swipe: function (a, b) {
        var c = $(b).parents(".chars-pane"), d = "in" == a ? "left" : "right", e = "in" == a ? "right" : "left";
        c.hide("slide", {direction: d}, 150, function () {
            c.siblings(".chars-pane").show("slide", {direction: e}, 150, function () {
                var a = $(this).find(".scrollbar-wrapper");
                a.length > 0 && a.tinyscrollbar()
            })
        })
    }, filter: function (a) {
        if (a.preventDefault(), a.stopPropagation(), Toggle.keepOpen = !0, a.keyCode != KeyCode.enter) {
            var b = $(a.srcElement || a.currentTarget), c = b.val().toLowerCase(), d = b.parents(".chars-pane").find(".overview");
            if (a.keyCode == KeyCode.esc && b.val(""), b.val().length < 1)d.children("a").removeClass("filtered"); else {
                d.children("a").each(function () {
                    $(this)[$(this).text().toLowerCase().indexOf(c) > -1 ? "removeClass" : "addClass"]("filtered")
                });
                var e = d.children("a.filtered").length >= d.children("a").length;
                d.children(".no-results")[e ? "show" : "hide"]()
            }
            var f = b.parents(".chars-pane:first").find(".scrollbar-wrapper");
            f.length > 0 && f.tinyscrollbar()
        }
    }
}, Flash = {
    videoPlayer: "",
    videoBase: "",
    ratingImage: "",
    expressInstall: "expressInstall.swf",
    requiredVersion: "10.2.154",
    initialize: function () {
        Flash.defaultVideoParams.base = Flash.videoBase, Flash.defaultVideoFlashVars.ratingPath = Flash.ratingImage, Flash.defaultVideoFlashVars.locale = Core.locale, Flash.defaultVideoFlashVars.dateFormat = Core.shortDateFormat
    },
    defaultVideoParams: {
        allowFullScreen: "true",
        bgcolor: "#000000",
        allowScriptAccess: "always",
        wmode: "opaque",
        menu: "false"
    },
    defaultVideoFlashVars: {ratingFadeTime: "2", ratingShowTime: "1", autoPlay: !0}
}, Locale = {
    dataPath: "data/i18n.frag", initialize: function () {
        var a = location.pathname.replace(Core.baseUrl, "");
        a += location.search || "?", $("#change-language, #service .service-language a").click(function () {
            return Locale.openMenu("#change-language", encodeURIComponent(a))
        })
    }, openMenu: function (a, b) {
        var c = $("#international");
        return a = $(a), b = b || "", c.is(":visible") ? (c.slideUp(), a.toggleClass("open")) : "" != c.html() ? (Locale.display(), a.toggleClass("open")) : $.ajax({
            url: Core.baseUrl + "/" + Locale.dataPath + "?path=" + b,
            dataType: "html",
            success: function (b) {
                b && (c.replaceWith(b), a.toggleClass("open"), Locale.display())
            }
        }), !1
    }, trackEvent: function (a, b) {
        try {
            _gaq.push(["_trackEvent", "Battle.net Language Change Event", a, b])
        } catch (c) {
        }
    }, display: function () {
        var a = $("#international");
        a.slideDown("fast", function () {
            $(this).css("display", "block")
        }), $.browser.opera || $("html, body").animate({scrollTop: a.offset().top}, 1e3)
    }
}, Toast = {
    container: null,
    initialized: !1,
    max: 5,
    options: {timer: 15e3, autoClose: !0, onClick: null},
    initialize: function () {
        Toast.container = $("<div/>").attr("id", "toast-container").show().appendTo("body"), Toast.initialized = !0
    },
    create: function (a) {
        var b = $("<div/>").addClass("ui-toast").hide().appendTo(Toast.container);
        return $("<div/>").addClass("toast-arrow").appendTo(b), $("<div/>").addClass("toast-top").appendTo(b), $("<div/>").addClass("toast-content").appendTo(b).html(a), $("<div/>").addClass("toast-bot").appendTo(b), $("<a/>").addClass("toast-close").attr("href", "javascript:;").appendTo(b).click(function (a) {
            a.preventDefault(), a.stopPropagation(), $(this).parent(".ui-toast").fadeOut("normal", function () {
                $(this).remove()
            })
        }), b
    },
    show: function (a, b) {
        Toast.initialized || Toast.initialize(), Toast.truncate();
        var c = Toast.create(a);
        b = $.extend({}, Toast.options, b), b.autoClose ? window.setTimeout(function () {
            c.fadeOut("normal", function () {
                c.remove()
            })
        }, b.timer) : c.click(function () {
            c.fadeOut("normal", function () {
                c.remove()
            })
        }).css("cursor", "pointer"), Core.isCallback(b.onClick) && c.click(b.onClick).css("cursor", "pointer"), c.fadeIn()
    },
    truncate: function () {
        var a = Toast.container.find(".ui-toast");
        a.length > Toast.max && Toast.container.find(".ui-toast:lt(" + Math.round(a.length - Toast.max) + ")").fadeOut()
    }
}, KeyCode = {
    backspace: 8,
    enter: 13,
    esc: 27,
    space: 32,
    tab: 9,
    arrowLeft: 37,
    arrowUp: 38,
    arrowRight: 39,
    arrowDown: 40,
    map: {
        global: {
            numbers: [48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105],
            letters: [65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90],
            controls: [8, 9, 13, 16, 17, 18, 20, 27, 33, 32, 34, 35, 36, 45, 46, 144],
            functions: [112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123],
            arrows: [37, 38, 39, 40],
            os: [17, 91, 92, 93, 219, 224]
        },
        de: {letters: [59, 192, 219, 222]},
        es: {letters: [59, 192]},
        ru: {letters: [59, 188, 190, 192, 219, 221, 222]},
        fr: {letters: [191]}
    },
    arrows: function (a) {
        return KeyCode.get("arrows", a)
    },
    controls: function (a) {
        return KeyCode.get("controls", a)
    },
    functions: function (a) {
        return KeyCode.get("functions", a)
    },
    get: function (a, b) {
        b = b || Core.getLanguage();
        var c = [], d = [];
        d = "string" == typeof a ? [a] : a;
        for (var e = 0, f = d.length; f > e; ++e) {
            var g = d[e];
            KeyCode.map.global[g] && (c = c.concat(KeyCode.map.global[g]), KeyCode.map[b] && KeyCode.map[b][g] && (c = c.concat(KeyCode.map[b][g])))
        }
        return c
    },
    isAlpha: function (a, b) {
        return $.inArray(a.which, KeyCode.get(["letters", "controls"], b)) >= 0
    },
    isAlnum: function (a, b) {
        return KeyCode.isAlpha(a, b) || KeyCode.isNumeric(a, b)
    },
    isNumeric: function (a, b) {
        return $.inArray(a.which, KeyCode.get(["numbers", "controls"], b)) >= 0 && !a.shiftKey
    },
    letters: function (a) {
        return KeyCode.get("letters", a)
    },
    numbers: function (a) {
        return KeyCode.get("numbers", a)
    }
}, BnetAds = {
    init: function (a, b) {
        $.ajax({
            url: "/marketing/",
            data: {showText: !0, locale: Core.formatLocale(2, "_"), size: b},
            dataType: "html",
            success: function (b) {
                if ("" !== b) {
                    var c = b.substring(b.indexOf("<body>"), b.indexOf("</body>") + 7);
                    $(a).find(".sidebar-content").html($(c).html()).removeClass("loading")
                }
            },
            error: function () {
                $(a).remove()
            },
            cache: !1,
            global: !1
        })
    }, bindTracking: function (a, b, c) {
        $(a).click(function () {
            try {
                _gaq.push(["_trackEvent", b, c, $(this).data("ad") + " [" + Core.locale + "]"])
            } catch (a) {
            }
        })
    }, trackImpression: function (a, b, c) {
        try {
            _gaq.push(["_trackEvent", a, b, c + " [" + Core.locale + "]"])
        } catch (d) {
        }
    }, trackEvent: function (a, b, c, d) {
        try {
            c = c ? c + " - " : "", _gaq.push(["_trackEvent", "Battle.net Ad Service", d ? "Ad Click-Throughs" : "Ad Impressions", "Ad " + encodeURIComponent(b.replace(" ", "_")) + " - " + c + Core.locale + " - " + a])
        } catch (e) {
        }
    }
}, UserAgent = {
    header: navigator.userAgent.toLowerCase(), browser: "other", version: null, initialize: function () {
        var a, b, c = UserAgent.header;
        -1 != c.indexOf("firefox") ? b = "ff" : -1 != c.indexOf("msie") ? b = "ie" : -1 != c.indexOf("chrome") ? b = "chrome" : -1 != c.indexOf("opera") ? b = "opera" : -1 != c.indexOf("safari") && (b = "safari"), "ff" == b ? a = /firefox\/([-.0-9]+)/.exec(c) : "ie" == b ? a = /msie ([-.0-9]+)/.exec(c) : "chrome" == b ? a = /chrome\/([-.0-9]+)/.exec(c) : "opera" == b ? a = /opera\/([-.0-9]+)/.exec(c) : "safari" == b && (a = /safari\/([-.0-9]+)/.exec(c)), UserAgent.browser = b, UserAgent.version = a[1].substring(0, 1);
        var d = b;
        UserAgent.version && (d += " " + b + UserAgent.version), "ie" != b || 6 != UserAgent.version && 7 != UserAgent.version || (d += " ie67"), $("html").addClass(d)
    }
}, Storage = {
    initialized: window.localStorage, get: function (a) {
        return Storage.initialized && a ? localStorage.getItem(a) : null
    }, getAll: function (a) {
        var b = [];
        if (!Storage.initialized)return b;
        for (var c = 0, d = localStorage.length, e = null; d > c; c++)e = localStorage.key(c), a && 0 !== e.indexOf(a) || b.push({
            key: e,
            value: localStorage[e]
        });
        return b
    }, has: function (a) {
        return null !== Storage.get(a)
    }, set: function (a, b) {
        if (Storage.initialized && a) {
            try {
                localStorage.setItem(a, b || "")
            } catch (c) {
                c == QUOTA_EXCEEDED_ERR && alert("Local storage quota exceeded, please clear your saved data.")
            }
            return !0
        }
        return !1
    }, clear: function () {
        Storage.initialized && localStorage.clear()
    }, remove: function (a) {
        Storage.initialized && a && localStorage.removeItem(a)
    }, size: function (a) {
        return a ? Storage.getAll(a).length : localStorage.length || 0
    }
}, Overlay = {
    cache: {},
    config: {ajax: !1, bindClose: !0, className: "", fadeSpeed: 250, blackout: !0},
    loaded: null,
    wrapper: null,
    initialize: function () {
        if (!Overlay.loaded || !Overlay.wrapper) {
            Overlay.wrapper = $("<div/>", {
                id: "overlay",
                "class": "ui-overlay"
            }).appendTo("body").hide(), $("<a/>").addClass("overlay-close").attr("href", "javascript:;").click(Overlay.close).appendTo(Overlay.wrapper);
            {
                var a = $("<div/>").addClass("overlay-top").appendTo(Overlay.wrapper), b = $("<div/>").addClass("overlay-bottom").appendTo(a);
                $("<div/>").addClass("overlay-middle").appendTo(b)
            }
            Overlay.loaded = !0
        }
    },
    close: function (a) {
        a = a ? a || 250 : 10, Core.isIE() ? Blackout.hide() : $("#blackout").fadeOut(a), Overlay.wrapper.fadeOut(a, function () {
            Overlay.placeholder && ($("#overlay-placeholder").replaceWith(Overlay.content).hide(), Overlay.placeholder = !1), Overlay.setContent(""), Overlay.wrapper.attr("class", "ui-overlay"), "overlay" !== Overlay.wrapper.attr("id") && Overlay.wrapper.hide()
        })
    },
    open: function (a, b) {
        Overlay.initialize(), b = $.extend({}, Overlay.config, b), b.className && Overlay.wrapper.addClass(b.className), b.blackout && (b.bindClose ? Blackout.show(null, function () {
            Overlay.close(b.fadeSpeed)
        }) : Blackout.show()), b.ajax ? Overlay.cache[a] ? Overlay.show(Overlay.cache[a]) : $.ajax({
            type: "GET",
            url: a,
            dataType: "html",
            beforeSend: function () {
                Overlay.reset(), Overlay.show()
            },
            success: function (b) {
                Overlay.cache[a] = b, Overlay.setContent(b)
            }
        }) : a.jquery ? Overlay.show($("<div>").append(a.clone().show()).remove().html()) : "#" === a.substr(0, 1) ? (Overlay.placeholder = !0, Overlay.content = $(a).clone(!0), $(a).before($("<span></span>").attr("id", "overlay-placeholder").hide()), Overlay.show($(a).show())) : Overlay.show(a)
    },
    openCustom: function (a, b) {
        Overlay.wrapper = $(a), Overlay.wrapper && (b = $.extend({}, Overlay.config, b), b.blackout && (b.bindClose ? Blackout.show(null, function () {
            Overlay.close(b.fadeSpeed)
        }) : Blackout.show()), Overlay.position())
    },
    position: function (a) {
        a = a || Overlay.wrapper;
        var b = a.outerWidth(), c = a.outerHeight(), d = Page.dimensions.width / 2 - b / 2, e = Page.dimensions.height / 2 - c / 2;
        Core.isIE(6) && (e = Page.scroll.top + e), a.show().css({
            left: d + "px",
            top: e + "px",
            position: Core.isIE(6) ? "absolute" : "fixed"
        })
    },
    reset: function () {
        Overlay.wrapper.find(".overlay-middle").html("").addClass("overlay-loading")
    },
    show: function (a) {
        Overlay.setContent(a), Overlay.position()
    },
    setContent: function (a) {
        null != a && Overlay.wrapper.find(".overlay-middle").html(a)
    }
}, OverlayWrapper = {
    cache: {},
    config: {bindClose: !0, className: "", fadeSpeed: 250, blackout: !0},
    wrapper: null,
    contentId: null,
    initialized: !1,
    initialize: function () {
        OverlayWrapper.wrapper = $("<div/>", {
            id: "overlay",
            "class": "ui-overlay"
        }).appendTo("body").hide(), $("<a/>").addClass("overlay-close").attr("href", "javascript:;").click(OverlayWrapper.close).appendTo(OverlayWrapper.wrapper);
        {
            var a = $("<div/>").addClass("overlay-top").appendTo(OverlayWrapper.wrapper), b = $("<div/>").addClass("overlay-bottom").appendTo(a);
            $("<div/>").addClass("overlay-middle").appendTo(b)
        }
        OverlayWrapper.initialized = !0
    },
    close: function (a) {
        OverlayWrapper.initialized && (a = null == a ? 10 : a, OverlayWrapper.config.blackout && Blackout.hide(), OverlayWrapper.wrapper.fadeOut(a, function () {
            $(OverlayWrapper.contentId).hide(), $(OverlayWrapper.contentId).appendTo(document.body), OverlayWrapper.wrapper.remove()
        }))
    },
    open: function (a, b) {
        OverlayWrapper.initialize(), b = $.extend({}, OverlayWrapper.config, b), b.className && OverlayWrapper.wrapper.addClass(b.className), b.blackout && (b.bindClose ? Blackout.show(null, function () {
            OverlayWrapper.close(b.fadeSpeed)
        }) : Blackout.show()), "#" === a.substr(0, 1) && (OverlayWrapper.contentId = a, OverlayWrapper.show(a))
    },
    position: function (a) {
        a = a || OverlayWrapper.wrapper;
        var b = a.outerWidth(), c = a.outerHeight(), d = Page.dimensions.width / 2 - b / 2, e = Page.dimensions.height / 2 - c / 2;
        Core.isIE(6) && (e = Page.scroll.top + e), a.show().css({
            left: d + "px",
            top: e + "px",
            position: Core.isIE(6) ? "absolute" : "fixed"
        })
    },
    reset: function () {
        OverlayWrapper.wrapper.find(".overlay-middle").html("").addClass("overlay-loading")
    },
    show: function (a) {
        OverlayWrapper.setContent(a), OverlayWrapper.position()
    },
    setContent: function (a) {
        null != a && ($(a).show(), $(a).appendTo(OverlayWrapper.wrapper.find(".overlay-middle")))
    }
}, Hash = {
    base: "aZbYcXdWeVfUgThSiRjQkPlOmNnMoLpKqJrIsHtGuFvEwDxCyBzA0123456789+/",
    delimiter: "!",
    empty: ".",
    batch: function (a) {
        for (var b = [], c = 0, d = a.length; d > c; c++)b.push(Hash.encode(a[c]));
        return Core.trimRight(b.join(Hash.delimiter), Hash.delimiter)
    },
    encode: function (a, b) {
        for (var c = "", d = Hash.base, e = Hash.empty, f = 0, g = a.length; g > f; f++)null !== a[f] ? c += d.charAt(a[f]) : b && (c += e);
        return Core.trimRight(c, e)
    },
    decode: function (a) {
        for (var b, c = [], d = Hash.base, e = Hash.empty, f = 0, g = a.length; g > f; f++)b = a.charAt(f), b = b == e ? null : d.indexOf(b), c.push(b);
        return c
    }
}, Prompt = {
    node: null,
    input: null,
    title: null,
    errors: null,
    initialized: !1,
    defaults: {minLength: {value: 1}, maxLength: {value: 25}, numeric: {value: !1}},
    rules: {},
    callback: null,
    initialize: function () {
        Prompt.node = $("<div/>").addClass("ui-prompt").click(Core.stopPropagation).appendTo("body");
        var a = $("<form/>").attr("method", "post").attr("action", "").addClass("prompt-inner").appendTo(Prompt.node).submit(Core.preventDefault).keyup(function (a) {
            a.which == KeyCode.enter && Prompt.validate()
        });
        Prompt.title = $("<h3/>").addClass("subheader").text("").appendTo(a), Prompt.input = $("<input/>").addClass("input").appendTo(a).focus(Input.activate).blur(Input.reset), Prompt.errors = $("<ul/>").addClass("prompt-errors").hide().appendTo(a);
        var b = $("<div/>").addClass("prompt-buttons").appendTo(a);
        $('<button type="button"/>').addClass("ui-button button1").html("<span><span>" + Msg.ui.submit + "</span></span>").click(Prompt.validate).appendTo(b), $('<button type="button"/>').addClass("ui-button button1").html("<span><span>" + Msg.ui.cancel + "</span></span>").click(Prompt.close).appendTo(b), $(document).bind("keyup.prompt", function (a) {
            a.which == KeyCode.esc && Prompt.close()
        }), Prompt.initialized = !0
    },
    open: function (a, b, c) {
        Prompt.initialized || Prompt.initialize();
        var d = Prompt.node.outerWidth(), e = Prompt.node.outerHeight(), f = Page.dimensions.width / 2 - d / 2, g = Page.dimensions.height / 2 - e / 2 + Page.scroll.top;
        Prompt.rules = $.extend({}, Prompt.defaults, c || {}), Prompt.callback = b, Prompt.title.text(a), Prompt.input.attr("maxlength", Prompt.rules.maxLength.value), Prompt.node.css({
            top: g,
            left: f
        }).show(), Blackout.show(function () {
            Prompt.input.focus()
        }, Prompt.close)
    },
    close: function () {
        Prompt.input.val("").trigger("blur"), Prompt.errors.empty().hide(), Prompt.node.hide(), Blackout.hide()
    },
    validate: function () {
        var a, b = Prompt.input, c = b.val().trim(), d = !0, e = [], f = 0, g = 0;
        for (var h in Prompt.rules)if (a = Prompt.rules[h], d = !0, a) {
            if ("function" == typeof a.value)d = a.value(c); else switch (h) {
                case"minLength":
                    a.value && c.length < a.value && (d = !1);
                    break;
                case"maxLength":
                    a.value && c.length > a.value && (d = !1);
                    break;
                case"numeric":
                    a.value && isNaN(c) && (d = !1)
            }
            d || e.push(a.message || h)
        }
        if (e.length)for (Prompt.errors.empty().show(), f = 0, g = e.length; g > f; f++)$("<li/>").text(e[f]).appendTo(Prompt.errors); else Core.isCallback(Prompt.callback) && Prompt.callback(c), Prompt.close()
    }
};
UserAgent.initialize(), String.prototype.trim = function () {
    return $.trim(this)
}, function () {
    var a = !1, b = /xyz/.test(function () {
    }) ? /\b_super\b/ : /.*/;
    window.Class = function () {
    }, Class.extend = function (c) {
        function d() {
            !a && this.init && this.init.apply(this, arguments)
        }

        var e = this.prototype;
        a = !0;
        var f = new this;
        a = !1;
        for (var g in c)f[g] = "function" == typeof c[g] && "function" == typeof e[g] && b.test(c[g]) ? function (a, b) {
            return function () {
                var c = this._super;
                this._super = e[a];
                var d = b.apply(this, arguments);
                return this._super = c, d
            }
        }(g, c[g]) : c[g];
        return d.prototype = f, d.constructor = d, d.extend = this.callee || arguments.callee, d
    }
}(), $.ajaxSetup({
    error: function (a, b) {
        if (4 != a.readyState)return !1;
        if ("login" == a.getResponseHeader("X-App"))return Login.openOrRedirect(), !1;
        if (a.status)switch (a.status) {
            case 301:
            case 302:
            case 307:
            case 403:
            case 404:
            case 500:
            case 503:
                return !1
        }
        return "error" != b || a.getAllResponseHeaders() ? !0 : !1
    }
});