# Use Node to run Angular dev server
FROM node:20-alpine
WORKDIR /app

# Copy package files and install dependencies
COPY cnab-importer-frontend/package*.json ./
RUN npm ci

# Copy source code
COPY cnab-importer-frontend/ ./

# Expose Angular dev server port
EXPOSE 4200

# Run Angular dev server
CMD ["npx", "ng", "serve", "--host", "0.0.0.0"]
