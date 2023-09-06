import {defineConfig} from 'vite'
import {resolve} from 'path'

export default defineConfig(({command}) => {

    if (command === "build") {
        return {
            build: {
                target: '',
                outDir: 'wwwroot',
                rollupOptions: {
                    input: {
                        'references/ready': resolve(__dirname, 'browser/references/ready.js'),
                        main: resolve(__dirname, 'browser/main.js'),
                        login: resolve(__dirname, 'browser/login.js'),
                        'signin-redirect': resolve(__dirname, 'browser/signin-redirect.js'),
                        'signout-redirect': resolve(__dirname, 'browser/signout-redirect.js')
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
        return {}
    }
})