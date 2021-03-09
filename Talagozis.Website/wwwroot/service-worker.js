importScripts("https://storage.googleapis.com/workbox-cdn/releases/5.1.2/workbox-sw.js");

// Enable/Disable debug console
workbox.setConfig({ debug: false });


const { registerRoute } = workbox.routing;
const { CacheFirst, StaleWhileRevalidate, NetworkFirst, NetworkOnly } = workbox.strategies;
const { CacheableResponsePlugin } = workbox.cacheableResponse;
const { ExpirationPlugin } = workbox.expiration;

if (workbox) {
    console.debug("Yay! Workbox is loaded 🎉");
} else {
    console.debug("Boo! Workbox didn't load 😬");
}



// Exclude visualstudio.com
workbox.routing.setDefaultHandler(
    ({ url }) => url.origin === "https://dc.services.visualstudio.com",
    new NetworkOnly()
);


// Cache the Google Fonts stylesheets with a stale-while-revalidate strategy.
registerRoute(
    ({ url }) => url.origin === "https://fonts.googleapis.com",
    new StaleWhileRevalidate({
        cacheName: "google-fonts-stylesheets"
    }),
    "GET"
);
// Cache the underlying font files with a cache-first strategy for 1 year.
registerRoute(
    ({ url }) => url.origin === "https://fonts.gstatic.com",
    new CacheFirst({
        cacheName: "google-fonts-webfonts",
        plugins: [
            new CacheableResponsePlugin({
                statuses: [0, 200]
            }),
            new ExpirationPlugin({
                maxAgeSeconds: 60 * 60 * 24 * 365,
                maxEntries: 30
            })
        ]
    }),
    "GET"
);

// Cache CSS files
registerRoute(
    ({ request }) => request.destination === "style",
    new StaleWhileRevalidate({
        cacheName: "static-resources-css"
    }),
    "GET"
);
// Cache JS files
registerRoute(
    ({ request }) => request.destination === "script",
    new StaleWhileRevalidate({
        cacheName: "static-resources-js"
    }),
    "GET"
);
// Cache Font files
registerRoute(
    ({ request }) => request.destination === "font",
    new StaleWhileRevalidate({
        cacheName: "static-resources-font"
    }),
    "GET"
);
// Cache image files
registerRoute(
    ({ request }) => request.destination === "image",
    new StaleWhileRevalidate({
        cacheName: "static-resources-img"
    }),
    "GET"
);
// Cache image files
registerRoute(
    ({ request }) => console.log(request.destination) && request.destination === "object",
    new StaleWhileRevalidate({
        cacheName: "static-resources-json"
    }),
    "GET"
);




// Cache default
workbox.routing.setDefaultHandler(
    new NetworkFirst({
        cacheName: "default-cache"
    }),
    "GET"
);
