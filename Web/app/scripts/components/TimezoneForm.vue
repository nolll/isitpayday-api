<template>
    <div v-if="isReady">
        <h3>Timezone</h3>
        <div class="timezone-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="t in timezones" :value="t.id" :key="t.id">{{t.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{timezoneName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Timezone } from '@/types/Timezone';
    import { Component, Prop, Vue } from 'vue-property-decorator';
    
    @Component
    export default class TimezoneForm extends Vue {
        @Prop() value!: string;
        @Prop() readonly timezones!: Timezone[];
        isFormVisible = false;
        
        get timezoneName() {
            for (const t of this.timezones) {
                if (t.id === this.value) {
                    return t.name;
                }
            }
            return '';
        }

        updateValue(event: any){
            this.close();
            this.$emit('input', event.target.value);
        }

        get isReady(){
            return this.timezones.length;
        }

        open() {
            this.isFormVisible = true;
        }

        close() {
            this.isFormVisible = false;
        }
    }
</script>