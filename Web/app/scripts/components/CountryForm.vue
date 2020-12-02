<template>
    <div>
        <h3>Country</h3>
        <div class="country-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue" >
                    <option v-for="c in countries" :value="c.id" :key="c.id">{{c.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                <span v-text="countryName"></span>
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Country } from '@/types/Country';
    import { Component, Prop, Vue } from 'vue-property-decorator';
    
    @Component
    export default class CountryForm extends Vue {
        @Prop() value!: string;
        @Prop() readonly countries!: Country[];
        isFormVisible = false;

        get countryName() {
            for (const c of this.countries) {
                if (c.id === this.value) {
                    return c.name;
                }
            }
            return '';
        }

        updateValue(event: any){
            this.close();
            this.$emit('input', event.target.value);
        }

        open() {
            this.isFormVisible = true;
        }

        close() {
            this.isFormVisible = false;
        }
    }
</script>