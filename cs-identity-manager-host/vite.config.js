import { defineConfig } from 'vite'
import { resolve } from 'path'

export default defineConfig(({ command }) => {

    if (command === "build") {
        return {
            build: {
                outDir: 'wwwroot',
                rollupOptions: {
                    input: {
                        main: resolve(__dirname, 'browser/main.js')
                    },
                    output: {
                        entryFileNames: '[name].js',
                        assetFileNames: (assetInfo) => {
                            let extType = assetInfo.name.split('.').at(1);
                            if (/ttf|woff2/i.test(extType)) {
                                return `css/web-fonts/[name].[ext]`;
                            }
                            if (/svg/i.test(extType)) {
                                return `images/[name].[ext]`;
                            }
                            return `css/[name].[ext]`;
                        }
                    }
                }
            }
        }

    } else {
        return {
        }
    }
})