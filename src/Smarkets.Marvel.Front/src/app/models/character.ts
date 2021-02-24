export interface Character {
    id: number;
    name: string;
    description: string;
    modified: string;
    thumbnailUrl: string;
    stories: Story[];
}

export interface Story {
    name: string;
    type: string;
}