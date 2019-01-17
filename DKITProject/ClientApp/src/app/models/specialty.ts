export class Specialty {
    constructor(
        public id: number,
        public name: string,
        public announce: string, 
        public content: string,
        public imgPreviev: string
    ){}
}

export class SpecialtyPreview {
    constructor(
        public id: number,
        public name: string,
        public announce: string, 
        public imgIcon: string
    ){}
}