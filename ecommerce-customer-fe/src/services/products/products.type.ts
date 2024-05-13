export type ProductDto = {
    id: number
    name: string
    price: number
    description: string
    image: string
    createdAt: string
    updatedAt: string
    creator: {
        id: number,
        name: string
    },
    category: {
        id: number,
        name: string
    }
}