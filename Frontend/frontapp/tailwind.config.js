import { nextui } from "@nextui-org/react";

/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
        "./node_modules/@nextui-org/theme/dist/**/*.{js,ts,jsx,tsx}"
    ],
    theme: {
        extend: {},
    },
    darkMode: "class",
    plugins: [nextui({
        prefix: "nextui", // prefix for themes variables
        addCommonColors: true, // override common colors (e.g. ",blue" "green", "pink").
        defaultTheme: "light", // default theme from the themes object
        defaultExtendTheme: "light", // default theme to extend on custom themes
        themes: {
          light: {
            layout: {
                'primary': '#70ED64',
                'secondary': '#2dd4bf',
                'brand': '#4ade80'
            }, // light theme layout tokens
            colors: {
                'primary': '#70ED64',
                'secondary': '#2dd4bf',
                'brand': '#4ade80'
            }, // light theme colors
          },
          dark: {
            layout: {
                'primary': '#70ED64',
                'secondary': '#2dd4bf',
                'brand': '#4ade80'
            }, // light theme layout tokens
            colors: {
                'primary': '#70ED64',
                'secondary': '#2dd4bf',
                'brand': '#4ade80'
            }, // light theme colors
          },
          // ... custom themes
        },
      })],
}

