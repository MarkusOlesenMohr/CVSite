import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import vueJsx from "@vitejs/plugin-vue-jsx";

// https://vitejs.dev/config/
export default defineConfig({
  base: "/dist/",
  build: {
    outDir: "../wwwroot/dist",
    emptyOutDir: true,
    manifest: true,
    rollupOptions: {
      input: {
        main: "./src/main.ts",
      },
    },
  },
  plugins: [vue(), vueJsx()],
  server: {
    hmr: {
      protocol: "ws",
    },
  },
});
