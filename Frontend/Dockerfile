# Build stage
FROM node:18-alpine
WORKDIR /app

# Copy package files first for better caching
COPY package.json package-lock.json* ./

# Install all dependencies (including devDependencies)
RUN npm install --frozen-lockfile

# Copy source files
COPY . .

# Build the app
RUN npm run build


EXPOSE 3000
CMD ["npm", "run", "preview", "--", "--host", "0.0.0.0", "--port", "3000"]
