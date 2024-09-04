# Etapa de construcción de la aplicación Vue.js
FROM node:18 AS build-vue
WORKDIR /app
COPY package*.json ./
RUN npm install
RUN npm install vite
RUN npm install -D sass
COPY . .
RUN npm run build

# Etapa de producción
FROM nginx:alpine AS production
COPY --from=build-vue /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]